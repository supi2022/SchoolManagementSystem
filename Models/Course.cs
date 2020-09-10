using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int? Id { get; set; }
        public string Code { get; set; }
        public string CourseName { get; set; }

        public virtual Branch IdNavigation { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
