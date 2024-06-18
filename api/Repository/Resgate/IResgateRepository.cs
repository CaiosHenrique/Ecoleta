using api.Models;

namespace api.Repository.Resgate
{
    public interface IResgateRepository
    {
        public Task<List<ResgateModel>> GetAllAsync();
        public Task<ResgateModel> GetByBrindeIdForUserAsync(int idBrinde, int idUtilizador);
        
    }
}