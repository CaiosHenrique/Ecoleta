using api.Data;
using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.EcoPonto
{
    public class EcoPontoRepository : IEcoPontoRepository
    {
        private readonly DataContext _context;

        public EcoPontoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<EcopontoModel>> GetIdAsync(int IdEcoponto)
        {
            var ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(e => e.IdEcoponto == IdEcoponto);
            return ecoponto;
        }

        public async Task<List<EcopontoModel>> GetAllAsync()
        {
            var ecopontos = await _context.TB_ECOPONTO.ToListAsync();
            return ecopontos;
        }

        public async Task<ActionResult<EcopontoModel>> PostAsync(EcopontoModel ecoponto)
        {
            ecoponto.IdEcoponto = 0;

            _context.TB_ECOPONTO.AddAsync(ecoponto);
            await _context.SaveChangesAsync();
            return ecoponto;
        }

        public async Task<ActionResult<EcopontoModel>> PutAsync(int id, EcopontoModel ecoponto)
        {
            var ecopontoexistente = await _context.TB_ECOPONTO.FirstOrDefaultAsync(e => e.IdEcoponto == id);

            _context.Entry(ecopontoexistente).CurrentValues.SetValues(ecoponto);
            await _context.SaveChangesAsync();
            return ecopontoexistente;
        }

        public async Task<ActionResult<EcopontoModel>> DeleteAsync(int IdEcoponto)
        {
            var ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync((EcopontoModel e) => e.IdEcoponto == IdEcoponto);
            _context.TB_ECOPONTO.Remove(ecoponto);
            await _context.SaveChangesAsync();
            return ecoponto;
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