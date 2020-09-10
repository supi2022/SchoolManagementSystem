using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public readonly log4net.ILog _log4net;

        IStudentRepository db;

        public StudentsController(IStudentRepository _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(StudentsController));
        }



        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("StudentsController GET ALL Action Method called");
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

        // GET: api/Students/5
        [HttpGet("{id}")]
        public IActionResult Get1(string enrollid)
        {
            Student data = new Student();
            try
            {
                data = db.GetDetail(enrollid);
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

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] Student obj)
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

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public IActionResult Put(string enrollid, [FromBody] Student std)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(enrollid, std);
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
        public IActionResult Delete(string enrollid)
        {
            try
            {
                var result = db.Delete(enrollid);
                if (result == 0)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest(enrollid);
            }
        }

    }
}
