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
    public class TransactionLineRepo : IEntityRepo<TransactionLine>
    {
        private readonly FuelStationContext _context;
        public TransactionLineRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TransactionLine entity)
        {
            await _context.TransactionLines.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.ID == id);
            if (foundTransactionLine is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.TransactionLines.Remove(foundTransactionLine);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransactionLine>> GetAllAsync()
        {
            return await _context.TransactionLines.AsNoTracking().ToListAsync();
        }

        public async Task<TransactionLine?> GetByIdAsync(Guid id)
        {
            return await _context.TransactionLines.AsNoTracking().Where(transactionLine => transactionLine.ID == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, TransactionLine entity)
        {
            var foundTransactionLine = await _context.TransactionLines.SingleOrDefaultAsync(transactionLine => transactionLine.ID == id);
            if (foundTransactionLine is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundTransactionLine.NetValue = entity.NetValue;
            foundTransactionLine.TotalValue = entity.TotalValue;
            foundTransactionLine.DiscountValue = entity.DiscountValue;
            foundTransactionLine.DiscountPercent = entity.DiscountPercent;
            foundTransactionLine.Quantity = entity.Quantity;
            foundTransactionLine.ItemID = entity.ItemID;
            foundTransactionLine.TransactionID = entity.TransactionID;
            
            await _context.SaveChangesAsync();
        }
    }
}
