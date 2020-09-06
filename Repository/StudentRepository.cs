using Microsoft.EntityFrameworkCore.Update.Internal;
using SchoolManagementSystem.Enum;
using SchoolManagementSystem.Interfaces;
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
        public virtual Student GetStudentDetails(string enrollId)
        {
            if (db != null)
            {
                return (db.Student.Where(x => x.EnrollmentNo == enrollId)).FirstOrDefault();
            }
            return null;

        }
        public int UpdateDetail(string enrollId, string Studentname)//newly added
        {
            if (db != null)
            {
                Student val = db.Student.Where(x => x.EnrollmentNo == enrollId).FirstOrDefault();
                Student valc = db.Student.Where(x => x.EnrollmentNo == enrollId).FirstOrDefault();
                if (val != null)
                {
                    db.Student.Remove(val);
                    db.SaveChanges();
                    if ((Studentname != "") && (Studentname!= null))
                        valc.Studentname = Studentname;
                    
                    db.Student.Add(valc);
                    db.SaveChanges();
                }
            }
            return 0;
        }


    }
}
