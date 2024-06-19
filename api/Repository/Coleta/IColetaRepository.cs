using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Coleta
{
    public interface IColetaRepository
    {
        public Task<List<ColetaModel>> GetAllAsync();
        public Task<ColetaModel> GetIdAsync(int IdColeta);
        public Task<ColetaModel> PostAsync(ColetaModel coleta);
        public Task<ActionResult<ColetaModel>> PutAsync(int IdColeta, ColetaModel coleta);
        public Task<ActionResult<ColetaModel>> DeleteAsync(int IdColeta);
        public Task<ActionResult> ConfirmarColeta(int IdEcoponto, int IdUtilizador, int[] classe, double peso);

    }
}