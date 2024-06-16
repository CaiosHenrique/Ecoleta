using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.EcoPoints
{
    public class EcoPointsRepository : IEcoPointsRepository
    {
        private readonly DataContext _context;
        public EcoPointsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EcopointsModel> GetIdMaterialAsync(int IdMaterial)
        {
            var ecopoint = await _context.TB_ECOPOINTS.FirstOrDefaultAsync(e => e.IdMaterial == IdMaterial);
            return ecopoint;
        }

        public async Task<ActionResult<int>> GetIdUtilizadorAsync(int IdUtilizador)
        {
            var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == IdUtilizador);
            return utilizador.TotalEcoPoints;
        }

        public async Task<List<EcopointsModel>> GetAllAsync()
        {
            var ecopoints = await _context.TB_ECOPOINTS.ToListAsync();
            return ecopoints;

        }

        public async Task PostAsync(EcopointsModel ecopoints)
        {
            _context.TB_ECOPOINTS.Add(ecopoints);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task PutAsync(EcopointsModel ecopoint, int IdUtilizador)
        {
            var utilizador = await _context.TB_UTILIZADOR.FindAsync(IdUtilizador);
            utilizador.TotalEcoPoints = ecopoint.TotalEcoPoints;


            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteAsync(int IdUtilizador)
        {
            var utilizador = await _context.TB_UTILIZADOR.FindAsync(IdUtilizador);
            utilizador.TotalEcoPoints = 0;
            await _context.SaveChangesAsync();
            return;
        }
    }
}