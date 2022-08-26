﻿using Contracts.Dtos;
using Domain.Common.Errors.Base;
using OneOf;
using System.Threading.Tasks;

namespace Services.Abstract.UseCaseServices
{
    public interface IBreweryBeersCommandServices
    {
        /// <summary>
        /// Add a beer defined with a ForCreationBeerDto object to the brewery identified by the BreweryId.
        /// If the brewery identified by id breweryId does not exist, it returns BreweryNotFound error (Number 404).
        /// If the beer name in creationBeerDto is already associated to an existing beer, it returns a BreweryBeerConflict (Number 409).
        /// </summary>
        /// <param name="BreweryId">Id of the brewery to which add the beer</param>
        /// <param name="ForCreationbeerDto">Beer to add</param>
        /// <returns>Returns the newly added Beer</returns>
        public Task<OneOf<CreatedBeerDto, IError>> AddBeerToBrewery(int breweryId, ForCreationBeerDto creationBeerDto);

        /// <summary>
        /// Removes the beer with id equals to BeerId from the brewery identified by the BreweryId.
        /// If the brewery does not exist, it returns a BreweryNotFound error (Number 404).
        /// If the beer does not exist, it returns a BreweryBeerNotFound error (Number 404).
        /// If deletion succeeds, it returns null.
        /// </summary>
        /// <param name="BreweryId">Id of the brewery from which remove the beer</param>
        /// <param name="BeerId">Id of the beer to remove</param>
        public Task<IError> RemoveBeerFromBrewery(int BreweryId, int BeerId);
    }
}
