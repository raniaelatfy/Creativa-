using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creativa.Repository;
using Creativa.Models;
using Creativa.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Creativa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {

        IRepository<Branch> branch;
        public BranchController(IRepository<Branch> branch)
        {
            this.branch = branch;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> Index()
        {
            return await branch.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> add(BranchModel branch)
        {
            Branch b = new Branch()
            {
                Name = branch.name,
                Organizationid = branch.OrgID,
            };
            await this.branch.Add(b);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, BranchModel model)
        {
            if (id != model.id)
            {
                return BadRequest();
            }
            try
            {
                Branch b = new Branch() {
                    Id = model.id,
                    Name = model.name,
                    Organizationid = model.OrgID,
                };

                await branch.Update(id, b);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExist(id))
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var _branch = await branch.Find(id);
            if (_branch == null)
            {
                return NotFound();
            }
            await branch.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetEventModel(int id)
        {
            var _branch = await branch.Find(id);

            if (_branch == null)
            {
                return NotFound();
            }

            return _branch;
        }
        private bool BranchExist(int id)
        {
            return branch.Find(id) != null;
        }
    }
}
