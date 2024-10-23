using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilestoneAssessment3.Models;
using MilestoneAssessment3.Services;

namespace MilestoneAssessment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nutritionController : ControllerBase
    {
        public readonly NutritionServices us;
        public nutritionController(NutritionServices us)
        {
            this.us = us;
        }
        [HttpGet]
        public async Task<List<Nutrition>> Get() =>
            await us.GetAll();

        [HttpGet("getId")]
        public async Task<ActionResult<Nutrition>> GetId(String id)
        {
            var user = await us.GetAll();
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> update(string id, Nutrition updateUser)
        {
            var all = await us.GetAll();
            if (all is null)
            {
                return BadRequest();
            }
            updateUser.UserId = id;

            await us.UpdateUser(id, updateUser);

            return NoContent();

        }

        [HttpDelete]

        public async Task<ActionResult> Delete(string id)
        {
            var user = await us.GetAll();
            if (user is null)
            {
                return BadRequest();
            }
            await us.Remove(id);
            return NoContent();
        }
        [HttpDelete("DeleteByWorkoutID")]
        public async Task<ActionResult> DeleteByWorkoutID(string id)
        {
            var user = await us.GetAll();
            if (user is null)
            {
                return BadRequest();
            }
            await us.Remove(id);
            return NoContent();
        }

        [HttpGet("getByWorkoutType")]

        public async Task<ActionResult<Nutrition>> getByWorkoutType(String id)
        {
            var user = await us.GetAll();
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
