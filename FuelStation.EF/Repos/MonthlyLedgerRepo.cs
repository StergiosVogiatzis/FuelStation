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
    public class MonthlyLedgerRepo : IEntityRepo<MonthlyLedger>
    {
        private readonly FuelStationContext _context;
        public MonthlyLedgerRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(MonthlyLedger entity)
        {
            await _context.MonthlyLedgers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundMonthlyLedger = await _context.MonthlyLedgers.SingleOrDefaultAsync(monthlyLedger => monthlyLedger.ID == id);
            if (foundMonthlyLedger is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.MonthlyLedgers.Remove(foundMonthlyLedger);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MonthlyLedger>> GetAllAsync()
        {
            return await _context.MonthlyLedgers.AsNoTracking().ToListAsync();
        }

        public async Task<MonthlyLedger?> GetByIdAsync(Guid id)
        {
            return await _context.MonthlyLedgers.AsNoTracking().Where(monthlyLedger => monthlyLedger.ID == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, MonthlyLedger entity)
        {
            var foundMonthlyLedger = await _context.MonthlyLedgers.SingleOrDefaultAsync(monthlyLedger => monthlyLedger.ID == id);
            if (foundMonthlyLedger is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundMonthlyLedger.Year = entity.Year;
            foundMonthlyLedger.Month = entity.Month;
            foundMonthlyLedger.Income = entity.Income;
            foundMonthlyLedger.Expenses = entity.Expenses;
            foundMonthlyLedger.Total = entity.Total;
            foundMonthlyLedger.RentCost = entity.RentCost;
            await _context.SaveChangesAsync();
        }
        public async Task<bool> MonthlyLedgerExists(MonthlyLedger monthlyLedger)
        {
            return await _context.MonthlyLedgers.FirstOrDefaultAsync(monthlyL => monthlyL.Year == monthlyLedger.Year && monthlyL.Month == monthlyLedger.Month) is not null;
        }
    }
}
