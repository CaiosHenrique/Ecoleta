using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Resgate
{
    public class ResgateService : IResgateService
    {

        private readonly DataContext _context;

        public ResgateService(DataContext context)
        {
            _context = context;
        }
       

        public async Task GetAsync(int idBrinde)
        {
           var resgate = await _context.TB_RESGATE
                    .FirstOrDefaultAsync(x => x.IdBrinde == idBrinde);
           if (resgate == null)
           {
               throw new System.Exception("Brinde não encontrado");
           }
            
        }
       
        
    }
}