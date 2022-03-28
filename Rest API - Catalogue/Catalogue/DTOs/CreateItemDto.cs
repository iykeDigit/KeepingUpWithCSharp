using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.DTOs
{
    public record CreateItemDto
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}
