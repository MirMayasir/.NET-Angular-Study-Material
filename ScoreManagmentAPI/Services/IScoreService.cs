using ScoreManagmentAPI.Models;

namespace ScoreManagmentAPI.Services
{
    public interface IScoreService
    {
        Task<IEnumerable<Score>> GetAllScoresAsync();
        Task<Score> GetScoreByIdAsync(int id);
        Task AddScoreAsync(Score score);
        Task UpdateScoreAsync(Score score);
        Task DeleteScoreAsync(int id);
    }
}
