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

        public async Task<ActionResult<ColetaModel>> PutAsync(int IdColeta, ColetaModel coleta)
        {
            var coletaAtual = await _context.TB_COLETA.FirstOrDefaultAsync((ColetaModel c) => c.IdColeta == IdColeta);

                coletaAtual.IdColeta = coleta.IdColeta;
                coletaAtual.IdEcoponto = coleta.IdEcoponto;
                coletaAtual.IdUtilizador = coleta.IdUtilizador;
                coletaAtual.DataColeta = coleta.DataColeta;
                coletaAtual.Peso = coleta.Peso;
                coletaAtual.SituacaoColeta = coleta.SituacaoColeta;

                _context.Entry(coletaAtual).State = EntityState.Modified;


                await _context.SaveChangesAsync();

                return coletaAtual;
        }
        

        public async Task<ActionResult<ColetaModel>> DeleteAsync(int IdColeta)
        {
            var coleta = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdColeta == IdColeta);

            _context.TB_COLETA.Remove(coleta);
            await _context.SaveChangesAsync();
            return coleta;
        }

        public async Task<ActionResult> ConfirmarColeta(int IdEcoponto, int IdUtilizador, int[] classe, double peso)
        {
            
            if (classe == null || classe.Length == 0 || peso <= 0)
            {
                return new BadRequestResult(); 
            }

            
            int totalEcopoints = Convert.ToInt32(classe.Sum(c => ValorEcopointPorClasse(c) + 0.4 * peso));

            
            var utilizador = await _context.TB_UTILIZADOR.FindAsync(IdUtilizador);
            if (utilizador != null)
            {
                utilizador.TotalEcoPoints += totalEcopoints;
            }
            else
            {
                return new NotFoundResult(); 
            }

            
            var coleta = await _context.TB_COLETA.FirstOrDefaultAsync(c => c.IdEcoponto == IdEcoponto && c.IdUtilizador == IdUtilizador);
            if (coleta != null)
            {
                coleta.SituacaoColeta = "Concluído";
            }
            else
            {
                return new NotFoundResult(); 
            }

            
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        private int ValorEcopointPorClasse(int classe)
        {
            
            switch (classe)
            {
                case 1:
                    return 10;
                case 2:
                    return 20;
                case 3:
                    return 30;
                case 4:
                    return 40;
                case 5:
                    return 50;
                case 6:
                    return 60;
                case 7:
                    return 70;
                case 8:
                    return 80;
                case 9:
                    return 90;
                case 10:
                    return 100;
                default:
                    return 0;
            }
        }

    }
}