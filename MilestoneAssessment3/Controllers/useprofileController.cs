using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilestoneAssessment3.Models;
using MilestoneAssessment3.Services;
using ZstdSharp.Unsafe;

namespace MilestoneAssessment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class useprofileController : ControllerBase
    {

        public readonly userprofileServices us;

        public useprofileController(userprofileServices us)
        {
            this.us = us;
        }

        [HttpGet]
        public async Task<List<UserProfile>> Get() =>
            await us.GetAll();

        [HttpGet("getId")]
        public async Task<ActionResult<UserProfile>> GetId(String id)
        {
            var user = await us.GetAll();
            if(user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> update(string id, UserProfile updateUser)
        {
            var all = await us.GetAll();
            if(all is null)
            {
                return BadRequest();
            }
            updateUser.id = id;

            await us.UpdateUser(id, updateUser);

            return NoContent();

        }

        [HttpDelete]

        public async Task<ActionResult> Delete(string id)
        {
            var user = await us.GetAll();
            if( user is null)
            {
                return BadRequest();
            }
            await us.Remove(id);
            return NoContent();
        }
    }
}
