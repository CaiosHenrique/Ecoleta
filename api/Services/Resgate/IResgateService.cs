using api.Models;

namespace api.Services.Resgate
{
    public interface IResgateService
    {

        public Task GetAsync(int idBrinde);
        
    }
}