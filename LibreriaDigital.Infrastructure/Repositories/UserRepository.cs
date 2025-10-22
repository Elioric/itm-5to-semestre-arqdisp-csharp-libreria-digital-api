using Microsoft.EntityFrameworkCore;
using LibreriaDigital.Application.Interfaces;
using LibreriaDigital.Domain.Entities;
using LibreriaDigital.Infrastructure.Data;

namespace LibreriaDigital.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibreriaDigitalAppDbContext _context;

        public UserRepository(LibreriaDigitalAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                            .Include(u => u.Books)
                            .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                            .Include(u => u.Books)
                            .FirstOrDefaultAsync(u => u.Id == id);
                            // .FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> ExistsAsync(int id)
        {
            return _context.Users.AnyAsync(e => e.Id == id);
        }
    }
}