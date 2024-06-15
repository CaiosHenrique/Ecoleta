using api.Services.EcoPonto;
using api.Models;

namespace api.Services.EcoPonto
{
    public interface IEcoPontoService
    {
        public Task GetAsync(int IdEcoponto);
        public Task DeleteAsync(int IdEcoponto);
        public Task AutenticarEcoPontoAsync(EcopontoModel ecoponto);
        public Task AutenticarTBEcoPontoAsync(EcopontoModel ecoponto);
        public Task AutenticarSenhaEcoPonto(EcopontoModel ecoponto);
    }
}