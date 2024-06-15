using api.Models;

namespace api.Services.Coleta
{

    public interface IColetaService
    {
        public Task<ColetaModel> GetAsync(int IdColeta);
        public Task<ColetaModel> PutAsync(int IdColeta);
        public Task DeleteAsync(int IdColeta);
        
    }
}