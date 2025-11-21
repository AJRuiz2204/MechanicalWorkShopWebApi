using Mechanical_workshop.Models;

namespace MechanicalWorkShopWebApi.Domain.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByUsername(string username);
        Task Add(User user);
        Task SaveChanges();
    }
}
