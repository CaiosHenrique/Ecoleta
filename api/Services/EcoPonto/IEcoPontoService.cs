using api.Services.EcoPonto;
using api.Models;

namespace api.Services.EcoPonto
{
    public interface IEcoPontoService
    {
        public Task GetAsync(int IdEcoponto);
        public Task DeleteAsync(int IdEcoponto);
        public Task AutenticarEcoPontoAsync(string username);
        public Task AutenticarTBEcoPontoAsync(string username);
    }
}