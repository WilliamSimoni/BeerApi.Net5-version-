using System;

namespace Contracts.Dtos
{
    public record GetWholesalerDto
    {
        public int WholesalerId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
