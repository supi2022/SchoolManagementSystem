using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public readonly log4net.ILog _log4net;

        ICourseRepository db;

        public CoursesController(ICourseRepository _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(CoursesController));
        }



        // GET: api/Courses
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("CoursesController GET ALL Action Method called");
            try
            {
                var obj = db.GetDetails();
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public IActionResult Get1(string cd)
        {
            Course data = new Course();
            try
            {
                data = db.GetDetail(cd);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data);
            }
        }

        // POST: api/Courses
        [HttpPost]
        public IActionResult Post([FromBody] Course obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != null)
                        return Ok(res);

                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public IActionResult Put(string cd, [FromBody] Course std)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(cd, std);
                    if (result != 1)
                        return NotFound();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string cd)
        {
            try
            {
                var result = db.Delete(cd);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(cd);
            }
        }

    }
}
