using System;
using System.ComponentModel.DataAnnotations;

namespace Catalogue.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}