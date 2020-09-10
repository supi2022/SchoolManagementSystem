using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public partial class StudentCourse
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string StdCourseId { get; set; }

        public virtual Course StdCourse { get; set; }
        public virtual Student Student { get; set; }
    }
}
