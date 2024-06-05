using api.Data;
using api.Models;
using api.Services.EcoPonto;
using api.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using api.Utils;

namespace api.Services.Ecoponto
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

        public async Task AutenticarEcoPontoAsync(EcopontoModel ecoponto)
        {
            if (ecoponto == null)
            {
            throw new NotFoundException("Ecoponto não encontrado");
            }
        }

        public async Task AutenticarTBEcoPontoAsync(EcopontoModel ecoponto)
        {
            EcopontoModel EcoPonto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

            if (EcoPonto == null)
            {
                throw new NotFoundException("Ecoponto não encontrado");
            }
        }

        public async Task AutenticarSenhaEcoPonto(EcopontoModel ecoponto)
        {
            EcopontoModel EcoPonto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

            if (!Criptografia.VerificarPasswordHash(ecoponto.PasswordString, EcoPonto.PasswordHash, EcoPonto.PasswordSalt))
            {
                throw new UnauthorizedException("Senha incorreta");
            }
        }
    }
}