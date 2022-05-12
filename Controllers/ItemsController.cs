using Microsoft.AspNetCore.Mvc;
using Catalog.Repositories;
using Catalog.DTOs;
using Catalog.Interfaces;
using Catalog.Entities;

namespace Catalog.Controllers
{
    // GET /items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository _repository;

        public ItemsController(IInMemItemsRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            var items = _repository.GetItems().Select(item => item.AsDTO());

            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDTO();
        }

        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO item)
        {
            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(newItem);

            return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem.AsDTO());
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDTO> UpdateItem(Guid id, UpdateItemDTO item)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = item.Name,
                Price = item.Price
            };

            _repository.UpdateItem(updatedItem);

            return updatedItem.AsDTO();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _repository.DeleteItem(id);

            return NoContent();
        }
    }
}