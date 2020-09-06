using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly SchoolManagementSystemDBContext _context;
        readonly log4net.ILog _log4net;
        public BranchesController(SchoolManagementSystemDBContext context)
        {
            _context = context;
            _log4net = log4net.LogManager.GetLogger(typeof(BranchesController));
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranch()
        {
            return await _context.Branch.ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return branch;
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, Branch branch)
        {
            if (id != branch.Id)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Branches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranch(Branch branch)
        {
            _context.Branch.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = branch.Id }, branch);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();

            return branch;
        }

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.Id == id);
        }
    }
}
