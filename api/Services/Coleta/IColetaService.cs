namespace api.Services.Coleta
{

    public interface IColetaService
    {
        Task GetAsync(int IdColeta);
        Task PutAsync(int IdColeta);
        Task DeleteAsync(int IdColeta);
        
    }
}