using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySQLwebAPI.Model;
using MySQLwebAPI.Repositery;
using MySQLwebAPI.Services;
using System.Diagnostics.Eventing.Reader;

namespace MySQLwebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WiproController : ControllerBase
    {
        private readonly IEmployeRepo<Employee> _emp;

        public WiproController(IEmployeRepo<Employee> emp)
        {
            _emp = emp;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(_emp.getAll());
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee e)
        {
            if (ModelState.IsValid)
            {
                _emp.AddEmp(e);
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetEmployeById")]

        public async Task<ActionResult<Employee>> GetEmployeById(int id){
            var a = _emp.getEmpById(id);
            return Ok(a);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateEmpDetails(int id, Employee emp)
        {
            if (ModelState.IsValid)
            {
                _emp.EditEmp(id, emp);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteEmp(int id)
        {
            if (ModelState.IsValid) {
                _emp.Equals(id);
                return Ok();
             }
            else
            {
                return BadRequest();
            }
        }
        
    }
}
