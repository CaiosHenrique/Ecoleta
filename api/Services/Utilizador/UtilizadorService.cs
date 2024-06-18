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
        var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == id);

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

    public async Task RegistrarUserExistente(string username)
    {
            var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.Username == username);

            if (await UsuarioExistente(username))
            {
                    throw new System.Exception("Nome de usuário já existe");
            }
      
    }

    public async Task AutenticarUsuarioAsync(string username, string passwordString)
    {
        UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));


        if (usuario == null)
        {
            throw new System.Exception("Usuário não encontrado.");
        }
        else if (!Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt))
        {
            throw new System.Exception("Senha incorreta.");
        }
    }


    public async Task GetUserAsync(string username)
    {
            UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));                   
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
    }



public void AddEcoPoints(int IdUtilizador, int quantidade)
    {
        // Busque o usuário pelo ID
        var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

        // Verifique se o usuário existe
        if (utilizador == null)
        {
            throw new Exception("User not found");
        }

        // Adicione a quantidade de EcoPoints ao total de EcoPoints do usuário
        utilizador.TotalEcoPoints += quantidade;

        // Salve as alterações no banco de dados
        _context.SaveChanges();
    }
    
    }
}