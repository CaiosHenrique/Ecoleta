using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Coleta
{
    public class ColetaRepository : IColetaRepository
    {
        private readonly DataContext _context;
        public ColetaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ColetaModel>> GetAllAsync()
        {
            var coletas = await _context.TB_COLETA.ToListAsync();
            return coletas;
        }

        public async Task<ActionResult<ColetaModel>> GetIdAsync(int Id)
        {
            var coleta = await _context.TB_COLETA.FirstOrDefaultAsync( c => c.IdColeta == Id);
            return coleta;
        }

        public async Task<ActionResult<ColetaModel>> PostAsync(ColetaModel coleta)
        {
            var Coleta = _context.TB_COLETA.Add(coleta);
            await _context.SaveChangesAsync();
            return Coleta.Entity;
        }

        public async Task<ActionResult<ColetaModel>> PutAsync(int IdColeta, ColetaModel coleta)
        {
            var coletaAtual = await _context.TB_COLETA.FindAsync(IdColeta);

                coletaAtual.IdColeta = coleta.IdColeta;
                coletaAtual.IdEcoponto = coleta.IdEcoponto;
                coletaAtual.IdUtilizador = coleta.IdUtilizador;
                coletaAtual.CodigoEcoponto = coleta.CodigoEcoponto;
                coletaAtual.CodigoUtilizador = coleta.CodigoUtilizador;
                coletaAtual.DataColeta = coleta.DataColeta;
                coletaAtual.TotalEcopoints = coleta.TotalEcopoints;
                coletaAtual.Peso = coleta.Peso;
                coletaAtual.SituacaoColeta = coleta.SituacaoColeta;

                _context.TB_COLETA.Update(coletaAtual);
                _context.SaveChangesAsync();

                return coletaAtual;
        }
        

        public async Task<ActionResult<ColetaModel>> DeleteAsync(int IdColeta)
        {
            var coleta = await _context.TB_COLETA.FindAsync(IdColeta);

            _context.TB_COLETA.Remove(coleta);
            _context.SaveChangesAsync();
            return coleta;
        }

    }
}