using Microsoft.EntityFrameworkCore;
using modul21.Models.Entitys;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace modul21.Models.DataBase.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  DataBase=PhoneBookDB;
                  Trusted_Connection=True;"
                );
        }
    }
}
