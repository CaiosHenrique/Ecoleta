using api.Models;
using api.Data;
using api.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Coleta
{

    public class ColetaService : IColetaService
    {

        
        private readonly DataContext _context;

        public ColetaService(DataContext context)
        {
            _context = context;
        }
        
        public async Task GetAsync(int IdColeta)
        {
                var coleta = _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);

                if (coleta == null)
                {
                throw new NotFoundException("Coleta não encontrada");
                }
        }

        public async Task PutAsync(int IdColeta)
        {
            var coletaAtual = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);

                if (coletaAtual == null)
                {
                    throw new ConflictException("Dados inválidos");
                }
        }

        public async Task DeleteAsync(int IdColeta)
        {
            var coleta = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);

                if (coleta == null)
                {

                    throw new NotFoundException("Coleta não encontrada");
                }
        }
    }


}