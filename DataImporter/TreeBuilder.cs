using DataAccess.Management;
using DataImporter.ASD;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataImporter
{
    internal class TreeBuilder
    {
        public static List<SimpleTreeNode<Department>> NestedDepartments()
        {
            var allDepart = new List<SimpleTreeNode<Department>>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var departments = db.Departments.Select(x => x).ToList();
                foreach (var department in departments)
                {
                    var node = new SimpleTreeNode<Department>(department);
                    allDepart.Add(node);
                }
                foreach (var node in allDepart)
                {
                    node.Parent = allDepart.FirstOrDefault(x => x.NodeValue.ID == node.NodeValue.ParentID);
                    if (node.Parent != null)
                    {
                        node.Parent.Children.Add(node);
                    }
                }

                var root = allDepart.FirstOrDefault(x => x.NodeValue.ID == 2);
                var tree = new SimpleTree<Department>(root);

                return tree.GetAllNodes();
            }
        }
    }
}
