using Microsoft.EntityFrameworkCore;
using Test.Data.Models;

namespace Test.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;


        public DataContext() {  }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.LastActivityDate).HasColumnType("Date");
            modelBuilder.Entity<User>().Property(x => x.RegistrationDate).HasColumnType("Date");

            base.OnModelCreating(modelBuilder);
        }
    }
}