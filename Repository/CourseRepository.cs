using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
namespace SchoolManagementSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        SchoolManagementSystemDBContext db;
        public CourseRepository(SchoolManagementSystemDBContext _db)
        {
            db = _db;
        }

        public string AddDetail(Course br)
        {
            db.Course.Add(br);
            db.SaveChanges();

            return br.Code;
        }


        public int Delete(string id)
        {
            int result = 0;

            if (db != null)
            {

                var post = db.Course.FirstOrDefault(x => x.Code== id);

                if (post != null)
                {

                    db.Course.Remove(post);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }

            return result;
        }



        public Course GetDetail(string id)
        {
            if (db != null)
            {
                return (db.Course.Where(x => x.Code == id)).FirstOrDefault();
            }
            return null;
        }


        public List<Course> GetDetails()
        {
            return db.Course.ToList();
        }

        public int UpdateDetail(string id, Course br)
        {
            if (db != null)
            {
                var obj = (db.Course.Where(x => x.Code == id)).FirstOrDefault();
                if (obj != null)
                {
                    obj.Id = br.Id;
                    obj.Code = br.Code;
                    obj.CourseName = br.CourseName;
                    db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

    }
}
