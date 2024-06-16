using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ColetaModel> GetIdAsync(int IdColeta)
        {
            var coleta = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);
            return coleta;
        }

        public async Task<ColetaModel> PostAsync(ColetaModel Coleta)
        {
            _context.TB_COLETA.Add(Coleta);
            await _context.SaveChangesAsync();
            return Coleta;
        }

        public async Task<ColetaModel> PutAsync(int IdColeta, ColetaModel coleta)
        {
            var coletaAtual = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);

                coletaAtual.IdColeta = coleta.IdColeta;
                coletaAtual.IdEcoponto = coleta.IdEcoponto;
                coletaAtual.IdUtilizador = coleta.IdUtilizador;
                coletaAtual.CodigoEcoponto = coleta.CodigoEcoponto;
                coletaAtual.CodigoUtilizador = coleta.CodigoUtilizador;
                coletaAtual.DataColeta = coleta.DataColeta;
                coletaAtual.TotalEcopoints = coleta.TotalEcopoints;
                coletaAtual.Peso = coleta.Peso;
                coletaAtual.SituacaoColeta = coleta.SituacaoColeta;

                _context.Entry(coletaAtual).State = EntityState.Modified;


                await _context.SaveChangesAsync();

                return coletaAtual;
        }
        

        public async Task<ColetaModel> DeleteAsync(int IdColeta)
        {
            var coleta = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);

            _context.TB_COLETA.Remove(coleta);
            await _context.SaveChangesAsync();
            return coleta;
        }

    }
}