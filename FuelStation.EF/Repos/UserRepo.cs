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
    public class UserRepo : IEntityRepo<User>
    {
        private readonly FuelStationContext _context;
        public UserRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundUser = await _context.Users.SingleOrDefaultAsync(user => user.ID == id);
            if (foundUser is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.Users.Remove(foundUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().Where(user => user.ID == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, User entity)
        {
            var foundUser = await _context.Users.SingleOrDefaultAsync(user => user.ID == id);
            if (foundUser is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundUser.Name = entity.Name;
            foundUser.Surname = entity.Surname;
            foundUser.Username = entity.Username;
            foundUser.PasswordHash = entity.PasswordHash;
            
            await _context.SaveChangesAsync();
        }
        
    }
}
