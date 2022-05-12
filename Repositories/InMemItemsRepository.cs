using Catalog.Interfaces;
using Catalog.Entities;
using System.Linq;

namespace Catalog.Repositories
{

    public class InMemItemsRepository : IInMemItemsRepository
    {
        private readonly List<Item> items = new List<Item>(){
            new Item {
                Id = Guid.NewGuid(),
                Name = "Potion of healing",
                Price = 9,
                CreatedAt = DateTimeOffset.UtcNow
            },

            new Item {
                Id = Guid.NewGuid(),
                Name = "Potion of mana",
                Price = 10,
                CreatedAt = DateTimeOffset.UtcNow
            },

            new Item {
                Id = Guid.NewGuid(),
                Name = "Potion of strength",
                Price = 11,
                CreatedAt = DateTimeOffset.UtcNow
            },

            new Item {
                Id = Guid.NewGuid(),
                Name = "Iron sword",
                Price = 20,
                CreatedAt = DateTimeOffset.UtcNow
            },

            new Item {
                Id = Guid.NewGuid(),
                Name = "Iron armor",
                Price = 30,
                CreatedAt = DateTimeOffset.UtcNow
            },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }

    }
}