﻿using Contracts.Dtos;
using Domain.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Threading.Tasks;

namespace BeerApi.Controllers
{
    [Route("api/wholesalers")]
    [ApiController]
    [ApiVersion("1.0")]
    public class WholesalerCommandController : ControllerBase
    {

        private readonly ILoggerManager _logger;
        private readonly IServicesWrapper _services;

        public WholesalerCommandController(ILoggerManager logger, IServicesWrapper services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpPatch("{wholesalerId}/beers/{beerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdatedInventoryBeerDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBeerQuantity(int wholesalerId, int beerId, [FromBody] ForUpdateInventoryBeerDto updateBeerDto)
        {

            var serviceResult = await _services.ChangeWholesaler.UpdateQuantity(wholesalerId, beerId, updateBeerDto);

            _logger.LogDebug("WholesalerCommandController received result from ChangeWholesaler.UpdateQuantity");

            return serviceResult.Match<ActionResult>(
                updatedInventoryDto => Ok(updatedInventoryDto),
                error => Problem(statusCode: error.Number, detail: error.Message)
                );
        }

    }
}
