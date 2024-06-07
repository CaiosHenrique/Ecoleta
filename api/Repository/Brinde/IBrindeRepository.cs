using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Brinde
{
    public interface IBrindeRepository
    {

        public Task<List<BrindeModel>> GetAllAsync();
        public Task<ActionResult<BrindeModel>> GetIdAsync(int id);
        public Task<ActionResult<BrindeModel>> PutAsync(int id, BrindeModel updatedBrinde);
        public Task<ActionResult<BrindeModel>> PostAsync(BrindeModel brinde);
        public Task<ActionResult<BrindeModel>> DeleteAsync(int id);
        
    }
}