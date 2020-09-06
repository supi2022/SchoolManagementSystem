using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Branchname { get; set; }
        public virtual List<Courses> Course { get; set; }
    }
}
