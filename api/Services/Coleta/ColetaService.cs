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
        
        public async Task<ColetaModel> GetAsync(int Id)
        {
                var coleta = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == Id);

                if (coleta == null)
                {
                throw new NotFoundException("Coleta não encontrada");
                }

                return coleta;
        }

        public async Task<ColetaModel> PutAsync(int IdColeta)
        {
            var coletaAtual = await _context.TB_COLETA.FindAsync(IdColeta);

                if (coletaAtual == null)
                {
                    throw new ConflictException("Dados inválidos");
                }
                return coletaAtual;
        }

        public async Task DeleteAsync(int IdColeta)
        {
            var coleta = await _context.TB_COLETA.FindAsync(IdColeta);

                if (coleta == null)
                {

                    throw new NotFoundException("Coleta não encontrada");
                }
        }
    }


}