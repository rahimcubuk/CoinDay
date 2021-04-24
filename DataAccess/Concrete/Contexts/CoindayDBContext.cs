using Core.Entities.Concrete;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class CoindayDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Coinday;Trusted_Connection=true");
        }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Coin> Coins { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
