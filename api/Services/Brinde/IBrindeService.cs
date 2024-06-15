using api.Models;

namespace api.Services.Brinde
{
    public interface IBrindeService
    {
        public Task<BrindeModel> GetAsync(int id);
        public Task<BrindeModel> PutAsync(int id);
        public Task DeleteAsync(int id);
    }

}