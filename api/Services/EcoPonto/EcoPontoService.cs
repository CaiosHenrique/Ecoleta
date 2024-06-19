using api.Data;
using api.Models;
using api.Services.EcoPonto;
using api.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using api.Utils;

namespace api.Services.EcoPonto
{
    public class EcoPontoService : IEcoPontoService
    {
        private readonly DataContext _context;

        public EcoPontoService(DataContext context)
        {
            _context = context;
        }

        public async Task GetAsync(int IdEcoponto)
        {
            
            EcopontoModel e = await _context.TB_ECOPONTO.FindAsync(IdEcoponto);

                if (e == null)
                {
                    throw new NotFoundException("Ecoponto não encontrado");
                }

        }

        public async Task DeleteAsync(int IdEcoponto)
        {
            EcopontoModel ecoponto = await _context.TB_ECOPONTO.FindAsync(IdEcoponto);

            if (ecoponto == null)
            {
                throw new NotFoundException("Ecoponto não encontrado");
            }

        }


        public async Task AutenticarEcoPontoAsync(string username)
        {
            if (username == null)
            {
            throw new ConflictException("Dados inválidos");
            }
        }

        public async Task AutenticarTBEcoPontoAsync(string username)
        {
            var nomeEcoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == username);

            if (nomeEcoponto == null)
            {
                throw new NotFoundException("Ecoponto não encontrado");
            }
        }

    }
}