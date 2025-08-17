using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcoreAssignment01.Context
{

    //Using Data Annotations
    internal class Student
    {

        [Key]
        public int ID { get; set; }

        [Required, MaxLength(50)]
        public string FName { get; set; }

        [Required, MaxLength(50)]
        public string LName { get; set; }

        public string Address { get; set; }
        public int Age { get; set; }

        [Column("DepartmentId")]
        public int Dep_Id { get; set; }
    }
}
