namespace api.Services.EcoPoints
{

    public interface IEcoPointsService
    {
        Task GetMaterial(int IdMaterial);
        Task GetUtilizador(int IdUtilizador);
        Task PutAsync(int IdUtilizador);
        Task DeleteAsync(int IdUtilizador);
    }
    
}