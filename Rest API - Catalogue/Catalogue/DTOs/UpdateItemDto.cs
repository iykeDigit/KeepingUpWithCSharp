using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.DTOs
{
    public class UpdateItemDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public decimal Price { get; init; }
    }
}
