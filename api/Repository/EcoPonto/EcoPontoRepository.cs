using api.Data;
using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;

namespace api.Repository.EcoPonto
{
    public class EcoPontoRepository : IEcoPontoRepository
    {
        private readonly DataContext _context;

        public EcoPontoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task GetIdAsync(int IdEcoponto)
        {
            EcopontoModel e = await _context.TB_ECOPONTO.FindAsync(IdEcoponto);
            return;
        }

        public async Task<IEnumerable<EcopontoModel>> GetAllAsync()
        {
            return await _context.TB_ECOPONTO.ToListAsync();
        }

        public async Task PostAsync(EcopontoModel ecoponto)
        {
            _context.TB_ECOPONTO.AddAsync(ecoponto);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task PutAsync(EcopontoModel ecoponto)
        {
            _context.TB_ECOPONTO.Update(ecoponto);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int IdEcoponto)
        {
            EcopontoModel e = await _context.TB_ECOPONTO.FindAsync(IdEcoponto);
            _context.TB_ECOPONTO.Remove(e);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task LoginEcopontoAsync(EcopontoModel ecoponto)
        {

           Criptografia.CriarPasswordHash(ecoponto.PasswordString, out byte[] hash, out byte[] salt);

                ecoponto.PasswordString = string.Empty;
                ecoponto.PasswordHash = hash;
                ecoponto.PasswordSalt = salt;

                await _context.TB_ECOPONTO.AddAsync(ecoponto);
                await _context.SaveChangesAsync();
        }

        public async Task AlterarSenhaAsync(EcopontoModel ecoponto)
        {
            
        EcopontoModel EcoPonto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);


        Criptografia.CriarPasswordHash(ecoponto.PasswordString, out byte[] hash, out byte[] salt);

        EcoPonto.PasswordString = string.Empty;
        EcoPonto.PasswordHash = hash;
        EcoPonto.PasswordSalt = salt;

        _context.TB_ECOPONTO.Update(EcoPonto);
        await _context.SaveChangesAsync();

        }
       
    }
}