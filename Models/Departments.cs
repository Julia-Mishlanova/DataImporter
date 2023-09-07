using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [AllowNull]
        public int? ParentID { get; set; }

        [ForeignKey("ParentID")]
        public virtual Department depart { get; set; }

        [AllowNull]
        public int? ManagerID { get; set; }

        [ForeignKey("ManagerID")]
        public virtual Employees Employees { get; set; }


        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
