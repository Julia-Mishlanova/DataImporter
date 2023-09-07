//using DataAccess.Management;
//using Models;
//using System.Collections.Generic;
//using System.Reflection.Emit;
//using System;
//using System.Linq;

//namespace DataImporter
//{
//    internal class DatabaseConsoleManager
//    {
//        private static string _connectionString;

//        public DatabaseConsoleManager()
//        {
//            _connectionString = ConnectionDB.ConnectionString();
//        }

//        public static void OutputCurrentDataStructure()
//        {
//            int? id = 0;
//            while (true)
//            {
//                Console.WriteLine("Введите ID подразделения...");
//                var text = Console.ReadLine();

//                if (int.TryParse(text, out int result))
//                {
//                    id = result;
//                    break;
//                }
//            }

//            if (id < 2)
//            {
//                DisplayAllDataFromDatabase();
//                Console.ReadKey();

//                return;
//            }

//            DisplayParentDepartmentsHierarchy(id);
//        }
//        private static void DisplayParentDepartmentsHierarchy(int? id)
//        {
//            List<Department> departments = new List<Department>();

//            using (ApplicationDbContext db = new ApplicationDbContext())
//            {
//                var entity = db.Department.FirstOrDefault(u => u.ID == id);
//                if (entity == null)
//                {
//                    return;
//                }
//                id = entity.ParentID;
//                departments.Add(entity);

//                while (id != null)
//                {
//                    entity = db.Department.FirstOrDefault(u => u.ID == id);
//                    id = entity.ParentID;

//                    departments.Add(entity);
//                }

//                int spacesCount = 0;
//                for (int i = departments.Count - 1; i >= 0; i--)
//                {
//                    spacesCount++;
//                    Console.WriteLine(new string('=', spacesCount) + departments[i].Name);
//                }

//                var employee = db.Employees.FirstOrDefault(u => u.ID == departments[0].ManagerID).FullName;
//                Console.WriteLine(new string(' ', spacesCount) + '*' + employee);

//                Console.ReadKey();
//            }
//        }
//        private static void DisplayAllDataFromDatabase()
//        {
//            using (ApplicationDbContext db = new ApplicationDbContext())
//            {
//                var ListOfNestedDepartments = TreeBuilder.NestedDepartments();

//                for (int i = 0; i < ListOfNestedDepartments.Count; i++)
//                {
//                    var departmentHead = db.Employees.FirstOrDefault(u => u.ID == ListOfNestedDepartments[i].NodeValue.ManagerID);
//                    var employees = db.Employees.Where(u => u.DepartmentId == ListOfNestedDepartments[i].NodeValue.ID
//                                                         && u.ID != ListOfNestedDepartments[i].NodeValue.ManagerID);

//                    Console.WriteLine(new string('=', ListOfNestedDepartments[i].Depth) + ListOfNestedDepartments[i].NodeValue.Name);
//                    Console.WriteLine(new string(' ', ListOfNestedDepartments[i].Depth) + '*' + departmentHead.FullName);

//                    foreach (var node in employees)
//                    {
//                        Console.WriteLine(new string(' ', ListOfNestedDepartments[i].Depth) + '-' + node.FullName);
//                    }
//                }
//            }
//        }
//    }
//}