﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.EF.Repos
{
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        private readonly FuelStationContext _context;
        public EmployeeRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.ID == id);
            if (foundEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.Employees.Remove(foundEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees.AsNoTracking().Where(employee => employee.ID == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, Employee entity)
        {
            var foundEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.ID == id);
            if (foundEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundEmployee.Name = entity.Name;
            foundEmployee.Surname = entity.Surname;
            foundEmployee.Sallary = entity.Sallary;
            foundEmployee.HireDateStart = entity.HireDateStart;
            foundEmployee.HireDateEnd = entity.HireDateEnd;
            foundEmployee.EmployeeType = entity.EmployeeType;
            await _context.SaveChangesAsync();
        }
    }
}

