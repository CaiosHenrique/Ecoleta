using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Utilizador
{
    public interface IUtilizadorRepository
    {

        public Task<List<UtilizadorModel>> GetAllAsync();
        public Task<ActionResult<UtilizadorModel>> GetByIdAsync(int id);
        public Task<ActionResult<UtilizadorModel>> PostAsync(UtilizadorModel utilizador);
        public Task<ActionResult<UtilizadorModel>> PutAsync(int id, UtilizadorModel utilizador);
        public Task<ActionResult<UtilizadorModel>> DeleteAsync(int id);
        public Task RegistrarUsuarioAsync(UtilizadorModel utilizador);
        public Task AutenticarUsuarioAsync(UtilizadorModel credenciais);
        public Task AlterarSenhaUsuarioAsync(UtilizadorModel credenciais);
        public Task AlterarEmailUsuarioAsync(UtilizadorModel u);
    }
}