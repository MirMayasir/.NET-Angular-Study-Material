using System.Collections.Generic;
using System.Threading.Tasks;
using ScoreManagmentAPI.Models;
using ScoreManagmentAPI.Repository;
using ScoreManagmentAPI.Services;

public class ScoreService : IScoreService
{
    private readonly IScoreRepository _scoreRepository;

    public ScoreService(IScoreRepository scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    public async Task<IEnumerable<Score>> GetAllScoresAsync()
    {
        return await _scoreRepository.GetAllScoresAsync();
    }

    public async Task<Score> GetScoreByIdAsync(int id)
    {
        return await _scoreRepository.GetScoreByIdAsync(id);
    }

    public async Task AddScoreAsync(Score score)
    {
        await _scoreRepository.AddScoreAsync(score);
    }

    public async Task UpdateScoreAsync(Score score)
    {
        await _scoreRepository.UpdateScoreAsync(score);
    }

    public async Task DeleteScoreAsync(int id)
    {
        await _scoreRepository.DeleteScoreAsync(id);
    }
}
