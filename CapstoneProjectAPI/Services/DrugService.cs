using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Repositery;

namespace CapstoneProjectAPI.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public async Task<IEnumerable<Drug>> GetAllDrugsAsync()
        {
            return await _drugRepository.GetAllDrugsAsync();
        }

        public async Task<Drug> GetDrugByIdAsync(int id)
        {
            return await _drugRepository.GetDrugByIdAsync(id);
        }
    }
}
