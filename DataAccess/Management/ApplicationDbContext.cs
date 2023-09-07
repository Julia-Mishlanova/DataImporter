using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Management
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public ApplicationDbContext()
        {
            if (Database.EnsureCreated())
            {
                
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mynewdatabase3;Username=postgres;Password=1");
        }
    }
}
