using Mechanical_workshop.Models;

namespace MechanicalWorkShopWebApi.Domain.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetAll();
        Task Add(User user);
        Task Update(User user);
        Task Delete(User user);
        Task SaveChanges();
    }
}
