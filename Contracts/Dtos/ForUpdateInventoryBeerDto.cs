﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos
{
    public record ForUpdateInventoryBeerDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "{0} cannot be smaller than {1}")]
        public int Quantity { get; set; }
    }
}
