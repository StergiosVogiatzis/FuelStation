using FuelStation.Blazor.Shared;
using FuelStation.EF.Repos;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepo _itemRepo;
        public ItemController(ItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<ItemViewModel>> GetItem()
        {
            var itemResult = await _itemRepo.GetAllAsync();
            return itemResult.Select(item => new ItemViewModel
            {
                ID = item.ID,
                Code = item.Code,
                Description = item.Description,
                ItemType = item.ItemType,
                Price = item.Price,
                Cost = item.Cost
            });
        }
        [HttpGet("{id}")]
        public async Task<ItemEditViewModel> Get(Guid id)
        {
            ItemEditViewModel viewModel = new();
            if (id != Guid.Empty)
            {
                var existing = await _itemRepo.GetByIdAsync(id);
                viewModel.ID = existing.ID;
                viewModel.Code = existing.Code;
                viewModel.Description = existing.Description;
                viewModel.ItemType = existing.ItemType;
                viewModel.Price = existing.Price;
                viewModel.Cost = existing.Cost;
            }
            return viewModel;
        }
        [HttpPost]
        public async Task Post(ItemEditViewModel item)
        {
            var newItem = new Item
            {
                ID = item.ID,
                Code = item.Code,
                Description = item.Description,
                ItemType = item.ItemType,
                Price = item.Price,
                Cost = item.Cost
            };
            if (await _itemRepo.CodeExists(newItem)) throw new ArgumentException("The given Code already exists.");

            await _itemRepo.CreateAsync(newItem);
        }
        [HttpDelete("{id}")]
        public async Task DeleteItem(Guid id)
        {
            await _itemRepo.DeleteAsync(id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(ItemEditViewModel item)
        {
            var itemToUpdate = await _itemRepo.GetByIdAsync(item.ID);
            if (itemToUpdate == null) return NotFound();
            itemToUpdate.Code = item.Code;
            itemToUpdate.Description = item.Description;
            itemToUpdate.ItemType = item.ItemType;
            itemToUpdate.Price = item.Price;
            itemToUpdate.Cost = item.Cost;

            await _itemRepo.UpdateAsync(item.ID, itemToUpdate);
            return Ok();
        }
    }
}
