using FuelStation.Blazor.Shared;
using FuelStation.EF.Repos;
using FuelStation.Model;
using FuelStation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonthlyLedgerController : ControllerBase
    {
        private MonthlyLedgerHandler _monthlyLedgerHandler;
        private readonly MonthlyLedgerRepo _monthlyLedgerRepo;
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly ItemRepo _itemRepo;
        public MonthlyLedgerController(MonthlyLedgerRepo monthlyledgerRepo,
                                       IEntityRepo<Transaction> transactionRepo,
                                       IEntityRepo<TransactionLine> transactionLineRepo,
                                       IEntityRepo<Employee> employeeRepo,
                                       ItemRepo itemRepo,
                                       MonthlyLedgerHandler monthlyLedgerHandler)
        {
            _monthlyLedgerRepo = monthlyledgerRepo;
            _monthlyLedgerHandler = monthlyLedgerHandler;
            _transactionRepo = transactionRepo;
            _transactionLineRepo = transactionLineRepo;
            _employeeRepo = employeeRepo;
            _itemRepo = itemRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<MonthlyLedgerViewModel>> Get()
        {
            var monthlyLedgerResult = await _monthlyLedgerRepo.GetAllAsync();
            return monthlyLedgerResult.Select(monthlyLedger => new MonthlyLedgerViewModel
            {
                ID = monthlyLedger.ID,
                Year = monthlyLedger.Year,
                Month = monthlyLedger.Month,
                Income = monthlyLedger.Income,
                Expenses = monthlyLedger.Expenses,
                Total = monthlyLedger.Total
            });
        }
        [HttpGet("{id}")]
        public async Task<MonthlyLedgerViewModel> Get(Guid id)
        {
            MonthlyLedgerViewModel viewModel = new();
            if (id != Guid.Empty)
            {
                var existing = await _monthlyLedgerRepo.GetByIdAsync(id);
                viewModel.ID = existing.ID;
                viewModel.Year = existing.Year;
                viewModel.Month = existing.Month;
                viewModel.Income = existing.Income;
                viewModel.Expenses = existing.Expenses;
                viewModel.Total = existing.Total;
            }
            return viewModel;
        }
        [HttpDelete("{ID}")]
        public async Task Delete(Guid id)
        {
            await _monthlyLedgerRepo.DeleteAsync(id);
        }
        [HttpPost]
        public async Task Post(MonthlyLedgerViewModel monthlyLedgerView)
        {
            var transactions = await _transactionRepo.GetAllAsync();
            var transactionLines = await _transactionLineRepo.GetAllAsync();
            var employees = await _employeeRepo.GetAllAsync();
            var items = await _itemRepo.GetAllAsync();

            var newLedger = new MonthlyLedger()
            {
                ID = monthlyLedgerView.ID,
                Year = monthlyLedgerView.Year,
                Month = monthlyLedgerView.Month,
                RentCost = monthlyLedgerView.RentCost
            };

            newLedger.Income = await _monthlyLedgerHandler.CalculateIncome(transactions);
            newLedger.Expenses = await _monthlyLedgerHandler.CalculateExpenses(employees, items, transactions, transactionLines, monthlyLedgerView.RentCost);
            newLedger.Total = newLedger.Income - newLedger.Expenses;
            if (await _monthlyLedgerRepo.MonthlyLedgerExists(newLedger))
                return;
            await _monthlyLedgerRepo.CreateAsync(newLedger);
        }
            
    }
}
