using System;
using System.ComponentModel.DataAnnotations;

namespace Catalogue.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}