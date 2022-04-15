using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.EF.Repos
{
    public class TransactionRepo : IEntityRepo<Transaction>
    {
        private readonly FuelStationContext _context;
        public TransactionRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Transaction entity)
        {
            await _context.Transactions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundTransaction = await _context.Transactions.SingleOrDefaultAsync(transaction => transaction.ID == id);
            if (foundTransaction is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.Transactions.Remove(foundTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.AsNoTracking().Where(transaction => transaction.ID == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, Transaction entity)
        {
            var foundTransaction = await _context.Transactions.SingleOrDefaultAsync(transaction => transaction.ID == id);
            if (foundTransaction is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundTransaction.EmployeeID = entity.EmployeeID;
            foundTransaction.CustomerID = entity.CustomerID;
            foundTransaction.TotalValue = entity.TotalValue;
            foundTransaction.PaymentMethod = entity.PaymentMethod;
            foundTransaction.Date = entity.Date;
            foundTransaction.TransactionLines = entity.TransactionLines;

            await _context.SaveChangesAsync();
        }
    }
}
