using api.Models;

namespace api.Repository.Utilizador
{
    public interface IUtilizadorRepository
    {

        public Task<List<UtilizadorModel>> GetAllAsync();
        public Task<UtilizadorModel> GetByIdAsync(int id);
        public Task PostAsync(UtilizadorModel utilizador);
        public Task PutAsync(int id, UtilizadorModel utilizador);
        public Task DeleteAsync(int id);
        public Task RegistrarUsuarioAsync(UtilizadorModel utilizador);
        public Task AutenticarUsuarioAsync(UtilizadorModel credenciais);
        public Task AlterarSenhaUsuarioAsync(UtilizadorModel credenciais);
        public Task AlterarEmailUsuarioAsync(UtilizadorModel u);
    }
}