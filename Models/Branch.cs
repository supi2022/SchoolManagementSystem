using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Branchname { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
