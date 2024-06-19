using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Utilizador
{
    public interface IUtilizadorRepository
    {

        public Task<List<UtilizadorModel>> GetAllAsync();
        public Task<ActionResult<UtilizadorModel>> GetByIdAsync(int id);
        public Task<ActionResult<UtilizadorModel>> PostAsync(UtilizadorModel utilizador);
        public Task<ActionResult<UtilizadorModel>> PutAsync(string username, UtilizadorModel utilizador);
        public Task<ActionResult<UtilizadorModel>> DeleteAsync(int id);
        public Task RegistrarUsuarioAsync(string username, string passwordString);
        public Task<bool> AutenticarUsuarioAsync(string username, string passwordString);
        public Task AlterarSenhaUsuarioAsync(string username, string novaSenha);
        public Task AlterarEmailUsuarioAsync(int idUtilizador, string email);
        public Task<string> ResgatarBrindeAsync(int idUtilizador, int idBrinde);
    }
}