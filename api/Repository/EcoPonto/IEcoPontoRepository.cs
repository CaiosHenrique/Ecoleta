using api.Models;

namespace api.Repository.EcoPonto
{
    public interface IEcoPontoRepository
    {
        public Task GetIdAsync(int IdEcoponto);
        public Task<IEnumerable<EcopontoModel>> GetAllAsync();
        public Task PostAsync(EcopontoModel ecoponto);
        public Task PutAsync(EcopontoModel ecoponto);
        public Task DeleteAsync(int IdEcoponto);
        public Task LoginEcopontoAsync(EcopontoModel ecoponto);
        public Task AlterarSenhaAsync(EcopontoModel ecoponto);
    }
}