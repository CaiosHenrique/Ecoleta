using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.Resgate
{
    public class ResgateRepository : IResgateRepository
    {

        private readonly DataContext _context;

        public ResgateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ResgateModel>> GetAllAsync(int idUtilizador)
        {
            var resgates = await _context.TB_RESGATE
                    .Where(x => x.IdUtilizador == idUtilizador)
                    .ToListAsync();
            return resgates;
        }

        public async Task<ResgateModel> GetByBrindeIdForUserAsync(int idBrinde, int idUtilizador)
        {
            var resgate = await _context.TB_RESGATE
                    .FirstOrDefaultAsync(x => x.IdBrinde == idBrinde && x.IdUtilizador == idUtilizador);
            return resgate;
        }
        
    }
}