using System.Collections.Generic;
using System.Threading.Tasks;
using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsWithLayersController : ControllerBase
    {
        private readonly IDrugService _drugService;

        public DrugsWithLayersController(IDrugService drugService)
        {
            _drugService = drugService;
        }

        // GET: api/DrugsWithLayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrugs()
        {
            var drugs = await _drugService.GetAllDrugsAsync();
            return Ok(drugs);
        }

        // GET: api/DrugsWithLayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
            var drug = await _drugService.GetDrugByIdAsync(id);
            if (drug == null)
            {
                return NotFound();
            }
            return Ok(drug);
        }
    }
}
