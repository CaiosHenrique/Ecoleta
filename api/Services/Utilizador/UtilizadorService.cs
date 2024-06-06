using api.Services.Exceptions;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Utils;

namespace api.Services.Utilizador
{
    public class UtilizadorService : IUtilizadorService
    {

    private readonly DataContext _context;
    public UtilizadorService(DataContext context)
    {
        _context = context;

    }


    public async Task GetAsync(int id)
    {
        var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == id);

         if (utilizador == null)
         {

         throw new NotFoundException("Utilizador não encontrado");

         }
    }

    public async Task PutAsync(int id)
    {
        var existingUtilizador = await _context.TB_UTILIZADOR.FindAsync(id);

            if (existingUtilizador == null)
            {
                throw new NotFoundException("Utilizador não encontrado");
            }
    }

    public async Task DeleteAsync(int id)
    {
        var utilizador = await _context.TB_UTILIZADOR.FindAsync((UtilizadorModel u) => u.IdUtilizador == id);

            if (utilizador == null)
            {
                
            throw new NotFoundException("Utilizador não encontrado");
            
            }
    }

    private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.TB_UTILIZADOR.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

    public async Task RegistrarUserExistente(UtilizadorModel utilizador)
    {
            if (await UsuarioExistente(utilizador.Username))
            {
                    throw new System.Exception("Nome de usuário já existe");
            }
    }

    public async Task AutenticarUsuarioAsync(UtilizadorModel credenciais)
    {
            UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));
                   
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
    }

    public async Task GetUserAsync(UtilizadorModel credenciais)
    {
        UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));
                   
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
    }




    }
}