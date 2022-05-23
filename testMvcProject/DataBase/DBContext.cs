using Microsoft.EntityFrameworkCore;
using testMvcProject.Models.Resources.ImplementedResources;
using testMvcProject.Models.Users;

namespace testMvcProject.DataBase
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        //public DbSet<Furniture> Furnitures { get; set; }
        //public DbSet<Profile> Profiles { get; set; }
        //public DbSet<Person> Persons { get; set; }
    }
}