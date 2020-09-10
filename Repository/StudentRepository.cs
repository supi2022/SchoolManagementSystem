using Microsoft.EntityFrameworkCore.Update.Internal;
using SchoolManagementSystem.Enum;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Repository
{
    public class StudentRepository:IStudentRepository
    {
        SchoolManagementSystemDBContext db;
        public StudentRepository(SchoolManagementSystemDBContext _db)
        {
            db = _db;
        }
        public List<Student> GetDetails()
        {
            return db.Student.ToList();
        }
        public  Student GetDetail(string enrollId)
        {
            if (db != null)
            {
                return (db.Student.Where(x => x.EnrollmentNo == enrollId)).FirstOrDefault();
            }
            return null;

        }
       

        public string AddDetail(Student std)//newlyadded
        {
            db.Student.Add(std);
            db.SaveChanges();

            return std.EnrollmentNo;
        }



        public int UpdateDetail(string enrollId, Student std)
        {
            if (db != null)
            {
                var obj = (db.Student.Where(x => x.EnrollmentNo == enrollId)).FirstOrDefault();
                if (obj != null)
                {
                    obj.Studentname = std.Studentname;
                    obj.Age = std.Age;
                    obj.Birthdate = std.Birthdate;
                    obj.EnrollmentNo= std.EnrollmentNo;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int Delete(string enrollId)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Student.FirstOrDefault(x => x.EnrollmentNo == enrollId);

                if (post != null)
                {

                    db.Student.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;

        }
    }
}



    

