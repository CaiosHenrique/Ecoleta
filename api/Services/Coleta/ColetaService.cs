using api.Models;
using api.Data;
using api.Services.Exceptions;

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
                var coleta = _context.TB_COLETA.Find(IdColeta);

                if (coleta == null)
                {
                throw new NotFoundException("Coleta não encontrada");
                }
        }

        public async Task PutAsync(int IdColeta)
        {
            var coletaAtual = _context.TB_COLETA.Find(IdColeta);

                if (coletaAtual == null)
                {
                    throw new ConflictException("Dados inválidos");
                }
        }

        public async Task DeleteAsync(int IdColeta)
        {
            var coleta = _context.TB_COLETA.Find(IdColeta);

                if (coleta == null)
                {

                    throw new NotFoundException("Coleta não encontrada");
                }
        }
    }


}