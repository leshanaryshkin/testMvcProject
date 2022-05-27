using Microsoft.EntityFrameworkCore;
using testMvcProject.Models.Resources.ImplementedResources;
using testMvcProject.Models.Users;

namespace testMvcProject.DataBase
{
    public class DBContext2 : DbContext
    {
        public DBContext2(DbContextOptions<DBContext2> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<UserLoginPassword> UsersLoginsPasswords { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Balance> Balances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Furniture>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Profile>()
                .HasIndex(p => new { p.Name })
                .IsUnique(true);

            modelBuilder.Entity<Balance>()
                .HasIndex(p => new { p.currencyName })
                .IsUnique(true);

            modelBuilder.Entity<User>()
                .HasIndex(p => new { p.telephone })
                .IsUnique(true);

        }
    }
}