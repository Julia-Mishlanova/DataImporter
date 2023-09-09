using DataAccess.Management;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Seeders
{
    internal class EmployeeSeeder
    {
        private static readonly ApplicationDbContext _db = new ApplicationDbContext();
        public static void SeedEmployees(List<List<string>> data)
        {
            var jobTitles = data[4];
            var fullNames = data[1];
            var passwords = data[3];
            var logins = data[2];

            //подгружаю новые JobTitles которых еще нет в бд
            JobTitleSeeder.SeedJobTitle(jobTitles);

            //подгружаю departments которых еще нет в бд
            var departments = data[0];
            for (int i = 0; i < departments.Count; i++)
            {
                var departmentName = departments[i];
                if (departmentName == "")
                {
                    continue;
                }

                if (_db.Departments.FirstOrDefault(u => u.Name == departmentName) == null)
                {
                    _db.Departments.Add(new Department { Name = departmentName });
                    _db.SaveChanges();
                }
            }

            for (int i = 0; i < data[0].Count; i++)
            {
                var departmentName = departments[i];
                var jobTitleName = jobTitles[i];

                var jobTitle = _db.JobTitles.FirstOrDefault(u => u.Name == jobTitleName);
                var department = _db.Departments.FirstOrDefault(u => u.Name == departmentName);

                if (department == null)
                {
                    department = _db.Departments.FirstOrDefault(u => u.ID == 1);
                }

                // update если имя сотрудника уже есть, а остальные поля пусты (при добавлении departments.tsv первым)
                var entity = _db.Employees.FirstOrDefault(u => u.FullName == fullNames[i]);
                if (entity != null)
                {
                    entity.DepartmentId = department.ID;
                    entity.Login = logins[i];
                    entity.Password = passwords[i];
                    entity.JobTitleId = jobTitle.ID;

                    _db.Update(entity);
                    _db.SaveChanges();
                    continue;
                }

                Employees employee = new Employees
                {
                    Department = department,
                    DepartmentId = department.ID,
                    FullName = fullNames[i],
                    Login = logins[i],
                    Password = passwords[i],
                    JobTitle = jobTitle,
                    JobTitleId = jobTitle.ID,
                };
                _db.Employees.Add(employee);
                _db.SaveChanges();
            }
        }
    }
}
