using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreManagmentAPI.Models;
using ScoreManagmentAPI.Services;

namespace ScoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreWithLayersController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreWithLayersController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        // GET: api/ScoreWithLayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return Ok(await _scoreService.GetAllScoresAsync());
        }

        // GET: api/ScoreWithLayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _scoreService.GetScoreByIdAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return Ok(score);
        }

        // PUT: api/ScoreWithLayers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(int id, Score score)
        {
            if (id != score.ScoreId)
            {
                return BadRequest();
            }

            await _scoreService.UpdateScoreAsync(score);

            return NoContent();
        }

        // POST: api/ScoreWithLayers
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            await _scoreService.AddScoreAsync(score);
            return CreatedAtAction(nameof(GetScore), new { id = score.ScoreId }, score);
        }

        // DELETE: api/ScoreWithLayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            var score = await _scoreService.GetScoreByIdAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            await _scoreService.DeleteScoreAsync(id);
            return NoContent();
        }
    }
}
