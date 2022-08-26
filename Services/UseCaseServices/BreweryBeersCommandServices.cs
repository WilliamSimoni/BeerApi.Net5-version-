﻿using Contracts.Dtos;
using Domain.Common.Errors;
using Domain.Common.Errors.Base;
using Domain.Entities;
using Domain.Logger;
using Domain.Repositories;
using MapsterMapper;
using OneOf;
using Services.Abstract.UseCaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.UseCaseServices
{
    public class BreweryBeersCommandServices : IBreweryBeersCommandServices
    {

        private readonly ILoggerManager _logger;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public BreweryBeersCommandServices(ILoggerManager logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<CreatedBeerDto, IError>> AddBeerToBrewery(int breweryId, ForCreationBeerDto creationBeerDto)
        {
            //check brewery existence
            var brewery = await _unitOfWork.QueryBrewery.GetByCondition(b => b.BreweryId == breweryId);

            if (!brewery.Any())
            {
                _logger.LogInfo("BreweryBeersCommandService tried to add a beer, but the id {1} did not correspond to any existing brewery", breweryId);
                return new BreweryNotFound(breweryId);
            }

            _logger.LogDebug("BreweryBeersCommandService found a brewery with id {1}. So, it can proceed with the addition of a beer", breweryId);

            var newBeer = _mapper.Map<Beer>(creationBeerDto);

            _logger.LogDebug("BreweryBeersCommandService mapped ForCreationBeerDto to BeerDto");

            //check if there exists a beer produced by the brewery with id breweryId
            //whose name is creationBeerDto.Name
            var beers = await _unitOfWork.QueryBeer
                .GetByCondition(b =>
                b.BreweryId == breweryId &&
                b.InProduction == true &&
                b.Name == newBeer.Name
                );

            if (beers.Any())
            {
                _logger.LogInfo("BreweryBeersCommandService tried to add a beer, but the name {1} is already assigned to an existing brewery", newBeer.Name);
                return new BreweryBeerConflict(newBeer.Name, breweryId);
            }

            _logger.LogDebug("BreweryBeersCommandService did not find breweries already associated with the name {1}. So, it can proceed with the addition of a beer", newBeer.Name);

            newBeer.BreweryId = breweryId;

            _unitOfWork.ChangeBeer.Add(newBeer);
            await _unitOfWork.SaveAsync();

            _logger.LogDebug("BreweryCommandService added a new beer with id {1} to the repository", newBeer.BeerId);


            return _mapper.Map<CreatedBeerDto>(newBeer);
        }

        public async Task<IError> RemoveBeerFromBrewery(int breweryId, int beerId)
        {
            //check brewery existence
            var brewery = await _unitOfWork.QueryBrewery.GetByCondition(b => b.BreweryId == breweryId);

            if (!brewery.Any())
            {
                _logger.LogInfo("BreweryBeersCommandService tried to remove a beer, but the id {1} did not correspond to any existing brewery", breweryId);
                return new BreweryNotFound(breweryId);
            }

            _logger.LogDebug("BreweryBeersCommandService found a brewery with id {1}. So, it can proceed with the deletion of the beer with id {2}", breweryId, beerId);


            //check if there exists a beer with id beerId produced by the brewery with id breweryId
            var beers = await _unitOfWork.QueryBeer
                .GetByCondition(b =>
                b.BreweryId == breweryId &&
                b.BeerId == beerId &&
                b.InProduction == true
                );

            if (!beers.Any())
            {
                _logger.LogInfo("BreweryBeersCommandService tried to remove a beer, but the id {1} did not correspond to any beer produced by the brewery with id {2}", beerId, breweryId);
                return new BreweryBeerNotFound(beerId, breweryId);
            }

            _logger.LogDebug("BreweryBeersCommandService found a beer with id {1} that the brewery with id {2} produces. So, it can proceed with deleting the beer with id {1}", beerId, breweryId);

            //set deletion fields (to soft delete the beer)
            var beer = beers.First();

            beer.InProduction = false;
            beer.OutOfProductionDate = DateTime.UtcNow;

            _unitOfWork.ChangeBeer.Update(beer);

            await _unitOfWork.SaveAsync();

            _logger.LogDebug("BreweryBeersCommandService (soft) deleted the beer with id {1} from the brewery with id {2} ", beerId, breweryId);

            return null;
        }
    }
}
