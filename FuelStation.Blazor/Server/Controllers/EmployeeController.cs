using FuelStation.Blazor.Shared;
using FuelStation.EF.Repos;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepo<Employee> _employeeRepo;
        public EmployeeController(IEntityRepo<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployee()
        {
            var engineerResult = await _employeeRepo.GetAllAsync();
            return engineerResult.Select(engineer => new EmployeeViewModel
            {
                ID = engineer.ID,
                Name = engineer.Name,
                Surname = engineer.Surname,
                HireDateStart = engineer.HireDateStart,
                HireDateEnd = engineer.HireDateEnd,
                EmployeeType = engineer.EmployeeType,
                Sallary = engineer.Sallary,
            });
        }
        [HttpGet("{id}")]
        public async Task<EmployeeEditViewModel> Get(Guid id)
        {
            EmployeeEditViewModel viewModel = new();
            if (id != Guid.Empty)
            {
                var existing = await _employeeRepo.GetByIdAsync(id);
                viewModel.ID = existing.ID;
                viewModel.Name = existing.Name;
                viewModel.Surname = existing.Surname;
                viewModel.Sallary = existing.Sallary;
                viewModel.HireDateStart = existing.HireDateStart;
                viewModel.HireDateEnd = existing.HireDateEnd;
                viewModel.EmployeeType = existing.EmployeeType;
                
            }
            return viewModel;
        }
        [HttpPost]
        public async Task Post(EmployeeEditViewModel employee)
        {
            var newEmployee = new Employee
            {

                ID = employee.ID,
                Name = employee.Name,
                Surname = employee.Surname,
                Sallary = employee.Sallary,
                HireDateStart = employee.HireDateStart,
                //HireDateEnd= employee.HireDateEnd,
                EmployeeType = employee.EmployeeType, 
            };
            await _employeeRepo.CreateAsync(newEmployee);
        }
        [HttpDelete("{id}")]
        public async Task DeleteEmployee(Guid id)
        {
            await _employeeRepo.DeleteAsync(id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(EmployeeEditViewModel employee)
        {
            var employeeToUpdate = await _employeeRepo.GetByIdAsync(employee.ID);
            if (employeeToUpdate == null) return NotFound();
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Surname = employee.Surname;
            employeeToUpdate.Sallary = employee.Sallary;
            employeeToUpdate.HireDateStart = employee.HireDateStart;
            employeeToUpdate.HireDateEnd = employee.HireDateEnd;
            employeeToUpdate.EmployeeType = employee.EmployeeType;

            await _employeeRepo.UpdateAsync(employee.ID, employeeToUpdate);

            return Ok();
        }
    }
}
