using api.Models;

namespace api.Services.Utilizador
{
    public interface IUtilizadorService
    {

        public Task GetAsync(int id);
        public Task PutAsync(string username);
        public Task DeleteAsync(int id);
        public Task RegistrarUserExistente(string username);
        public Task AutenticarUsuarioAsync(string username, string passwordString);
        public Task GetUserAsync(string username);
        public void AddEcoPoints(int IdUtilizador, int quantidade);
    }
}