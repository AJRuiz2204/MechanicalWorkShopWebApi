using Mechanical_workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicalWorkShopWebApi.Data
{
    public class WorkshopDbContext : DbContext
    {
        public WorkshopDbContext(DbContextOptions<WorkshopDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
