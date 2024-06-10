using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.EcoPoints
{
    public interface IEcoPointsRepository
    {
        public Task<EcopointsModel> GetIdMaterialAsync(int IdMaterial);
        public Task<ActionResult<int>> GetIdUtilizadorAsync(int IdUtilizador);
        public Task<List<EcopointsModel>> GetAllAsync();
        public Task PostAsync(EcopointsModel ecopoint);
        public Task PutAsync(EcopointsModel ecopoints, int IdUtilizador);
        public Task DeleteAsync(int IdUtilizador);
    }
}