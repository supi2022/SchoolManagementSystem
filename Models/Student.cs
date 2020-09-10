using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public string Studentname { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string EnrollmentNo { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
