//using DataAccess.Management;
//using Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataImporter.Seeders
//{
//    internal class DepartmentSeeder
//    {
//        private static ApplicationDbContext _db = new ApplicationDbContext();
        
//        public static void SeedDepartment(List<List<string>> data)
//        {
//            var nameDepartments = data[0];
//            var parentDepartNames = data[1];
//            var nameEmployees = data[2];
//            var phones = data[3];

//            for (int i = 0; i < nameEmployees.Count; i++)
//            {
//                if (_db.Employees.FirstOrDefault(u => u.FullName == nameEmployees[i]) == null)
//                {
//                    _db.Employees.Add(new Employees { FullName = nameEmployees[i] });
//                }
//            }

//            for (int i = 0; i < nameDepartments.Count; i++)
//            {
//                var entity = _db.Department.FirstOrDefault(u => u.Name == nameDepartments[i]);

//                if (entity != null)
//                {
//                    entity.Phone = phones[i];
//                    entity.Name = nameDepartments[i];

//                    if (nameEmployees[i] != "")
//                    {
//                        entity.ManagerID = _db.Employees.FirstOrDefault(u => u.FullName == nameEmployees[i]).ID;
//                    }
//                    if (parentDepartNames[i] != "")
//                    {
//                        entity.ParentID = _db.Department.FirstOrDefault(u => u.Name == parentDepartNames[i]).ID;
//                    }

//                    _db.Update(entity);
//                    _db.SaveChanges();
//                    continue;
//                }

//                entity = new Department
//                {
//                    Phone = phones[i],
//                    Name = nameDepartments[i],
//                };
//                _db.Department.Add(entity);
//                _db.SaveChanges();

//                var empl = _db.Employees.FirstOrDefault(u => u.FullName == nameEmployees[i]);
//                var dep = _db.Department.FirstOrDefault(u => u.Name == parentDepartNames[i]);

//                if (empl != null)
//                {
//                    entity.ManagerID = empl.ID;
//                }
//                if (dep != null)
//                {
//                    entity.ParentID = dep.ID;
//                }

//                _db.Update(entity);
//                _db.SaveChanges();
//            }
//        }
//    }
//}
