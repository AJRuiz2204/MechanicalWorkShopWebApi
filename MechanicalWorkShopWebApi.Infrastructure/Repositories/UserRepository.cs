using Mechanical_workshop.Models;
using MechanicalWorkShopWebApi.Data;
using MechanicalWorkShopWebApi.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MechanicalWorkShopWebApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkshopDbContext _context;

        public UserRepository(WorkshopDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
