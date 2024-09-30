using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
namespace RentApp.Models
{
    public class RentDbContext : DbContext
    {
        public RentDbContext()
        {

        }

        public RentDbContext(DbContextOptions<RentDbContext> options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MainPage> MainPages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MEHMET;Database=RentDb;Trusted_Connection=true;Encrypt=false;"
                );
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
    
}
