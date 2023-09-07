using DataAccess.Management;
using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataImporter.Seeders
{
    internal class Seeder
    {
        public static void SeedData(List<List<string>> data, string path)
        {
            //string fileName = Path.GetFileName(path).ToLower();

            //if (fileName == "jobtitle.tsv")
            //{
            //    var jobTitles = data[0];
            //    JobTitleSeeder.SeedJobTitle(jobTitles);
            //}
            //if (fileName == "employees.tsv")
            //{
            //    EmployeeSeeder.SeedEmployees(data);
            //}
            //if (fileName == "departments.tsv")
            //{
            //    DepartmentSeeder.SeedDepartment(data);
            //}
        }
    }
}
