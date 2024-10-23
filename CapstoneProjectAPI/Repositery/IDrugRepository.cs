using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Repositery
{
    public interface IDrugRepository
    {
        Task<IEnumerable<Drug>> GetAllDrugsAsync();
        Task<Drug> GetDrugByIdAsync(int id);
    }
}
