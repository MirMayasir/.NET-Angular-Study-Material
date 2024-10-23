using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreManagmentAPI.Models;
using ScoreManagmentAPI.Repository;

public class ScoreRepository : IScoreRepository
{
    private readonly ScoreMonitoringContext _context;

    public ScoreRepository(ScoreMonitoringContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Score>> GetAllScoresAsync()
    {
        return await _context.Scores.ToListAsync();
    }

    public async Task<Score> GetScoreByIdAsync(int id)
    {
        return await _context.Scores.FindAsync(id);
    }

    public async Task AddScoreAsync(Score score)
    {
        await _context.Scores.AddAsync(score);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateScoreAsync(Score score)
    {
        _context.Entry(score).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteScoreAsync(int id)
    {
        var score = await GetScoreByIdAsync(id);
        if (score != null)
        {
            _context.Scores.Remove(score);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ScoreExistsAsync(int id)
    {
        return await _context.Scores.AnyAsync(e => e.ScoreId == id);
    }
}
