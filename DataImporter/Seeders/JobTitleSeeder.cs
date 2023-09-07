﻿using DataAccess.Management;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Seeders
{
    internal class JobTitleSeeder
    {
        private static ApplicationDbContext _db = new ApplicationDbContext(ConnectionDB.ConnectionString());

        public static void SeedJobTitle(List<string> jobTitles)
        {
            for (int i = 0; i < jobTitles.Count; i++)
            {
                var jobTitleName = jobTitles[i];
                if (_db.JobTitles.FirstOrDefault(u => u.Name == jobTitleName) == null)
                {
                    _db.JobTitles.Add(new JobTitle { Name = jobTitleName });
                    _db.SaveChanges();
                }
            }
        }
    }
}
