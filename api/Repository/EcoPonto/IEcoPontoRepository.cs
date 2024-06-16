using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.EcoPonto
{
    public interface IEcoPontoRepository
    {
        public Task<ActionResult<EcopontoModel>> GetIdAsync(int IdEcoponto);
        public Task<List<EcopontoModel>> GetAllAsync();
        public Task<ActionResult<EcopontoModel>> PostAsync(EcopontoModel ecoponto);
        public Task<ActionResult<EcopontoModel>> PutAsync(int id, EcopontoModel ecoponto);
        public Task<ActionResult<EcopontoModel>> DeleteAsync(int IdEcoponto);
        public Task LoginEcopontoAsync(EcopontoModel ecoponto);
        public Task AlterarSenhaAsync(EcopontoModel ecoponto);
    }
}