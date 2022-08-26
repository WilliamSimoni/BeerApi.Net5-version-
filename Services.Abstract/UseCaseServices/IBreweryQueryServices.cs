﻿using Contracts.Dtos;
using Domain.Common.Errors.Base;
using OneOf;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstract.UseCaseServices
{
    public interface IBreweryQueryServices
    {
        /// <summary>
        /// Returns all the breweries saved in the database
        /// </summary>
        public Task<IEnumerable<BreweryDto>> GetAll();

        /// <summary>
        /// Returns the brewery with the id specified as a parameter.
        /// If there is not any brewery with the specified Id, it returns a BreweryNotFound error (Number 404).
        /// </summary>
        public Task<OneOf<BreweryDto, IError>> GetById(int breweryId);
    }
}
