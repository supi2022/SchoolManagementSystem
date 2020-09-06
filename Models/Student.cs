using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementSystem.Enum;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public string Studentname { get; set; }
        public int Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string EnrollmentNo { get; set; }
        public string Gender { get; set; }
        //public  List <Courses> EnrolledCourses { get; set; }
    }
    
}
