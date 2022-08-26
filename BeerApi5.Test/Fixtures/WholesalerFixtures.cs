﻿using Contracts.Dtos;
using Domain.Entities;
using System.Collections.Generic;

namespace BeerApi.Test.Fixtures
{
    public static class WholesalerFixtures
    {
        public static IEnumerable<Wholesaler> GetWholesalers()
        {
            return new List<Wholesaler>()
            {
                new Wholesaler()
                {
                    WholesalerId = 1,
                    Name = "thebeer",
                    Address = "jump street 21",
                    Email = "info@thebeer.be"
                },
                new Wholesaler()
                {
                    WholesalerId = 2,
                    Name = "berallax corp",
                    Address = "evergreen street 32",
                    Email = "contact@berallaxcorp.com"
                }
            };
        }

        public static IEnumerable<GetWholesalerDto> GetGetWholesalerDtos()
        {
            return new List<GetWholesalerDto>()
            {
                new GetWholesalerDto()
                {
                    WholesalerId = 1,
                    Name = "thebeer",
                    Address = "jump street 21",
                    Email = "info@thebeer.be"
                },
                new GetWholesalerDto()
                {
                    WholesalerId = 2,
                    Name = "berallax corp",
                    Address = "evergreen street 32",
                    Email = "contact@berallaxcorp.com"
                }
            };
        }
    }
}
