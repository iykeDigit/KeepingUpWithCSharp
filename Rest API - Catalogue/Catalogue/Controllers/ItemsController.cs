using Catalogue.DTOs;
using Catalogue.Entities;
using Catalogue.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;

        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }

        //GET / items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems() 
        {
            var items = _repository.GetItems().Select(item => item.AsDto());
            
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id) 
        {
            var item = _repository.GetItem(id);
            
            if(item is null) 
            {
                return NotFound();
            }
            return item.AsDto();
        }

        //Post / items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto) 
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            _repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
    }
}
