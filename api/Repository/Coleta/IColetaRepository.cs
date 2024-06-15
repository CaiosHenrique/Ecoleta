using api.Models;

namespace api.Repository.Coleta
{
    public interface IColetaRepository
    {
        public Task<List<ColetaModel>> GetAllAsync();
        public Task<ColetaModel> GetIdAsync(int IdColeta);
        public Task<ColetaModel> PostAsync(ColetaModel coleta);
        public Task<ColetaModel> PutAsync(int IdColeta, ColetaModel coleta);
        public Task<ColetaModel> DeleteAsync(int IdColeta);

    }
}