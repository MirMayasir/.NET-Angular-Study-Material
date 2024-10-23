using CapstoneProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneProjectAPI.Repositery
{
    public class DrugRepository : IDrugRepository
    {
        private readonly CapstoneProjectContext _context;

        public DrugRepository(CapstoneProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Drug>> GetAllDrugsAsync()
        {
            return await _context.Drugs.ToListAsync();
        }

        public async Task<Drug> GetDrugByIdAsync(int id)
        {
            return await _context.Drugs.FindAsync(id);
        }
    }
}
