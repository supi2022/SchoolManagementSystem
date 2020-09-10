using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Repository
{
    public interface ICourseRepository
    {
        public string AddDetail(Course br);
        public int Delete(string id);
        public Course GetDetail(string id);
        public List<Course> GetDetails();
        public int UpdateDetail(string id, Course br);


    }
}
