using FuelStation.Blazor.Shared;
using FuelStation.EF.Repos;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        public CustomerController(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetCustomer()
        {
            var customerResult = await _customerRepo.GetAllAsync();
            return customerResult.Select(customer => new CustomerViewModel
            {
                ID = customer.ID,
                Name = customer.Name,
                Surname = customer.Surname,
                CardNumber = customer.CardNumber
            });
        }
        [HttpGet("{id}")]
        public async Task<CustomerEditViewModel> Get(Guid id)
        {
            CustomerEditViewModel viewModel = new();
            if (id != Guid.Empty)
            {
                var existing = await _customerRepo.GetByIdAsync(id);
                viewModel.ID = existing.ID;
                viewModel.Name = existing.Name;
                viewModel.Surname = existing.Surname;
                viewModel.CardNumber = existing.CardNumber;
            }
            return viewModel;
        }
        [HttpPost]
        public async Task Post(CustomerEditViewModel customer)
        {
            var newCustomer = new Customer
            {
                ID = customer.ID,
                Name = customer.Name,
                Surname = customer.Surname,
                CardNumber = customer.CardNumber
            };
            await _customerRepo.CreateAsync(newCustomer);
        }
        [HttpDelete("{id}")]
        public async Task DeleteCustomer(Guid id)
        {
            await _customerRepo.DeleteAsync(id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(CustomerEditViewModel customer)
        {
            var customerToUpdate = await _customerRepo.GetByIdAsync(customer.ID);
            if (customerToUpdate == null) return NotFound();
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Surname = customer.Surname;
            customerToUpdate.CardNumber = customer.CardNumber;

            await _customerRepo.UpdateAsync(customer.ID, customerToUpdate);

            return Ok();
        }
    }
}
