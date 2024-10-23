using FirstAPI.Models;
using FirstAPI.Repositery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepo<Course> _courseRepo;

        public CoursesController(ICourseRepo<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            return Ok(_courseRepo.GetAll());

        }

        [HttpPost]

        public async Task<ActionResult> AddCourse(Course c)
        {
            if(ModelState.IsValid)
            {
                _courseRepo.AddCourse(c);
                return Ok();
            }
            else
            {
                return BadRequest("invalid course object");
            }
        }

        [HttpGet]
        [Route("GetCourseByID")]
        public async Task<ActionResult<Course>> GetCourseByID(int id)
        {
            return _courseRepo.GetByCourseId(id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(int id, Course c)
        {
            if(ModelState.IsValid)
            {
                _courseRepo.EditCourse(id, c);
                return Ok();
                
            }
            else
            {
                return BadRequest();
            }
        }

       


    }
}
