using api.Models;

namespace api.Services.Utilizador
{
    public interface IUtilizadorService
    {

        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
        public Task RegistrarUserExistente(string username);
        public Task AutenticarUsuarioAsync(string username, string passwordString);
        public Task GetUserAsync(UtilizadorModel credenciais);
        public void AddEcoPoints(int IdUtilizador, int quantidade);
    }
}