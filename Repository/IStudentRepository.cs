using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetDetails();
        public Student GetDetail(string enrollId);
        public string AddDetail(Student std);
        public int UpdateDetail(string enrollId, Student std);//newlyadded
        public int Delete(string enrollId);
    }
}
