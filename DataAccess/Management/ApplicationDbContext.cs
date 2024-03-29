﻿using Microsoft.EntityFrameworkCore;
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
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Departments.Add(
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
            optionsBuilder.UseNpgsql(ConnectionDB.ConnectionString());
        }
    }
}
