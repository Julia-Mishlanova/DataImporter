using DataAccess.Management;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Seeders
{
    internal class JobTitleSeeder
    {
        private static readonly ApplicationDbContext _db = new ApplicationDbContext();

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
