using ScoreManagmentAPI.Models;

namespace ScoreManagmentAPI.Repository
{
    public interface IScoreRepository
    {
        Task<IEnumerable<Score>> GetAllScoresAsync();
        Task<Score> GetScoreByIdAsync(int id);
        Task AddScoreAsync(Score score);
        Task UpdateScoreAsync(Score score);
        Task DeleteScoreAsync(int id);
        Task<bool> ScoreExistsAsync(int id);
    }
}
