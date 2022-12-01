using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=AgencyDB; User Id=SA; Password=Qwerty123; TrustServerCertificate=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamsNetwork> TeamsNetworks { get; set; }
    }
}
