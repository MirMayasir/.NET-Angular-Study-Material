using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Services
{
    public interface IDrugService
    {
        Task<IEnumerable<Drug>> GetAllDrugsAsync();
        Task<Drug> GetDrugByIdAsync(int id);
    }
}
