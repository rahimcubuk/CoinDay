using Core.Entities.Concrete;
using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Contexts
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You must add your database 
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=...;Trusted_Connection=true");
        }
        public DbSet<Default> Defaults { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
