using FlightAPI.Models;
using FlightAPI.ReopLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Microsoft.EntityFrameworkCore;
using FlightAPI.ServiceLayer;


namespace FlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRepoController : ControllerBase
    {
        private readonly IContactusRepo<Contactu> _contactusRepo;

        public ContactRepoController(IContactusRepo<Contactu> contactusRepo)
        {
            _contactusRepo = contactusRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contactu>>> GetAllContacts()
        {
            return Ok(_contactusRepo.getAll());
        }

        [HttpPost]
        public async Task<ActionResult> AddContactus(Contactu c)
        {
            if(ModelState.IsValid)
            {
                _contactusRepo.AddContact(c);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
