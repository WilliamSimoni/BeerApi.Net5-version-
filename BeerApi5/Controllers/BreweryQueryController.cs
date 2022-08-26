﻿
using Contracts.Dtos;
using Domain.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeerApi.Controllers
{
    [ApiController]
    [Route("api/breweries")]
    [ApiVersion("1.0")]
    public class BreweryQueryController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IServicesWrapper _services;

        public BreweryQueryController(ILoggerManager logger, IServicesWrapper services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BreweryDto>))]
        public async Task<IActionResult> GetAllBreweries()
        {
            var breweries = await _services.QueryBrewery.GetAll();

            _logger.LogDebug("BreweryQueryController received result from QueryBrewery.GetAll");

            return Ok(breweries);
        }

        [HttpGet("{breweryId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BreweryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBreweryById(int breweryId)
        {
            var serviceResult = await _services.QueryBrewery.GetById(breweryId);

            _logger.LogDebug("BreweryQueryController received result from QueryBrewery.GetById");

            return serviceResult.Match<ActionResult>(
                brewery => Ok(brewery),
                error => Problem(statusCode: error.Number, detail: error.Message)
                );
        }

        [HttpGet("{breweryId}/beers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BeerDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBeersFromBrewery(int breweryId)
        {
            var serviceResult = await _services.QueryBreweryBeers.GetAllBeers(breweryId);

            _logger.LogDebug("BreweryQueryController received result from QueryBreweryBeers.GetAllBeers");

            return serviceResult.Match<ActionResult>(
                beers => Ok(beers),
                error => Problem(statusCode: error.Number, detail: error.Message)
                );
        }

        [HttpGet("{breweryId}/beers/{beerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BeerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBeerByIdFromBrewery(int breweryId, int beerId)
        {
            var serviceResult = await _services.QueryBreweryBeers.GetBeerById(breweryId, beerId);

            _logger.LogDebug("BreweryQueryController received result from QueryBreweryBeers.GetBeerById");

            return serviceResult.Match<ActionResult>(
                    beer => Ok(beer),
                    error => Problem(statusCode: error.Number, detail: error.Message)
                );
        }
    }
}