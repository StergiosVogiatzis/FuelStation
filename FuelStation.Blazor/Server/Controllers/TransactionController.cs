using FuelStation.Blazor.Shared;
using FuelStation.EF.Repos;
using FuelStation.Model;
using FuelStation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<TransactionLine> _transactionRepoLine;
        private TransactionServices _transactionService;
        public TransactionController(IEntityRepo<Transaction> transactionRepo, TransactionServices transactionServices)
        {
            _transactionRepo = transactionRepo;
            _transactionService = transactionServices;
        }
        [HttpGet]
        public async Task<IEnumerable<TransactionViewModel>> Get()
        {
            var result = await _transactionRepo.GetAllAsync();
            return result.Select(x => new TransactionViewModel
            {
                ID = x.ID,
                Date = x.Date,
                EmployeeID = x.EmployeeID,
                EmployeeSurname = x.Employee.Surname,
                CustomerID = x.CustomerID,
                CustomerSurname = x.Customer.Surname,
                PaymentMethod = x.PaymentMethod,
                TotalValue = x.TotalValue
            });
            

        }
        [HttpGet("{id}")]
        public async Task<TransactionEditViewModel> GetTransaction(Guid id)
        {
            TransactionEditViewModel model = new();
            if (id != Guid.Empty)
            {
                var existing = await _transactionRepo.GetByIdAsync(id);
                model.ID = existing.ID;
                model.Date = existing.Date;
                model.CustomerID = existing.CustomerID;
                model.CustomerSurname= existing.Customer.Surname;
                model.EmployeeID = existing.EmployeeID;
                model.EmployeeSurname = existing.Employee.Surname;
                model.TotalValue = existing.TotalValue;

                model.TransactionLines = existing.TransactionLines.Select(transactionLine => new TransactionLineViewModel
                {
                    ID = transactionLine.ID,
                    TransactionID = transactionLine.TransactionID,
                    ItemID = transactionLine.ItemID,
                    Quantity = transactionLine.Quantity,
                    ItemPrice = transactionLine.ItemPrice,
                    NetValue = transactionLine.NetValue,
                    DiscountValue = transactionLine.DiscountValue,
                    DiscountPercent = transactionLine.DiscountPercent,
                    TotalValue = transactionLine.TotalValue
                }).ToList();
            }
            return model;
        }
        [HttpPost]
        public async Task Post(TransactionEditViewModel transaction)
        {
            var newTransaction = new Transaction
            {
                ID = transaction.ID,
                Date = transaction.Date,
                CustomerID = transaction.CustomerID,
                Customer = transaction.Customers,
                EmployeeID = transaction.EmployeeID,
                TotalValue = transaction.TotalValue,
                TransactionLines = transaction.TransactionLines.Select(transactionLine => new TransactionLine
                {
                    ID = transactionLine.ID,
                    TransactionID = transactionLine.TransactionID,
                    ItemID = transactionLine.ItemID,
                    Quantity = transactionLine.Quantity,
                    ItemPrice = transactionLine.ItemPrice,
                    NetValue = transactionLine.NetValue,
                    DiscountValue = transactionLine.DiscountValue,
                    DiscountPercent = transactionLine.DiscountPercent,
                    TotalValue = transactionLine.TotalValue
                }).ToList()
            };
                await _transactionRepo.CreateAsync(newTransaction);
        }
        [HttpDelete("{id}")]
        public async Task DeleteTransaction(Guid id)
        {
            await _transactionRepo.DeleteAsync(id);
        }
    }
}
