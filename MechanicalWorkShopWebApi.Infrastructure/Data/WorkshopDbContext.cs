using Mechanical_workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace MechanicalWorkShopWebApi.Data
{
    public class WorkshopDbContext : DbContext
    {
        public WorkshopDbContext(DbContextOptions<WorkshopDbContext> options) : base(options) { }

        public DbSet<UserWorkshop> UsersWorkshop { get; set; }
        public DbSet<WorkshopSettings> WorkshopSettings { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<UserWorkshop> UserWorkshop { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TechnicianDiagnostic> TechnicianDiagnostic { get; set; }
        public DbSet<SalesReport> SalesReport { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<LaborTaxMarkupSettings> LaborTaxMarkupSettings { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<EstimatePart> EstimatePart { get; set; }
        public DbSet<EstimateLabor> EstimateLabor { get; set; }
        public DbSet<EstimateFlatFee> EstimateFlatFee { get; set; }
        public DbSet<Estimate> Estimate { get; set; }
        public DbSet<Diagnostic> Diagnostic { get; set; }
        public DbSet<AccountReceivable> AccountReceivable { get; set; }
    }
}
