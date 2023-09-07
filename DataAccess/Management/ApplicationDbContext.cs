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
        public DbSet<Department> Department { get; set; }

        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
            if (Database.EnsureCreated())
            {
                using (ApplicationDbContext db = new ApplicationDbContext(_connectionString))
                {
                    db.Department.Add(
                        new Department
                        {
                            ParentID = null,
                            ID = 0,
                            Name = "SystemDepartmentName"
                        });
                    db.SaveChanges();
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
