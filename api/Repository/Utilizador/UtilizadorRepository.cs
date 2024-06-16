using api.Data;
using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Utilizador
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly DataContext _context;

        public UtilizadorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UtilizadorModel>> GetAllAsync()
        {
            var utilizadores = await _context.TB_UTILIZADOR.ToListAsync();
            return utilizadores;
        }

        public async Task<ActionResult<UtilizadorModel>> GetByIdAsync(int id)
        {
            var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync((UtilizadorModel u) => u.IdUtilizador == id);
            return utilizador;
        }

        public async Task<ActionResult<UtilizadorModel>> PostAsync(UtilizadorModel utilizador)
        {
            utilizador.IdUtilizador = 0;

            _context.TB_UTILIZADOR.Add(utilizador);
            await _context.SaveChangesAsync();
            return utilizador;
        }

        public async Task<ActionResult<UtilizadorModel>> PutAsync(int id, UtilizadorModel utilizador)
        {
            var existingUtilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync((UtilizadorModel u) => u.IdUtilizador == id);

            _context.Entry(existingUtilizador).CurrentValues.SetValues(utilizador);
            await _context.SaveChangesAsync();
            return existingUtilizador;
        }

        public async Task<ActionResult<UtilizadorModel>> DeleteAsync(int id)
        {
            var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync((UtilizadorModel u) => u.IdUtilizador == id);

            _context.TB_UTILIZADOR.Remove(utilizador);
            await _context.SaveChangesAsync();
            return utilizador;
        }

        public async Task RegistrarUsuarioAsync(UtilizadorModel utilizador)
        {
            Criptografia.CriarPasswordHash(utilizador.PasswordString, out byte[] hash, out byte[] salt);

                utilizador.PasswordString = string.Empty;
                utilizador.PasswordHash = hash;
                utilizador.PasswordSalt = salt;

                await _context.TB_UTILIZADOR.AddAsync(utilizador);
                await _context.SaveChangesAsync();
        }

        public async Task AutenticarUsuarioAsync(UtilizadorModel credenciais)
        {
            UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));
                   
            usuario.DataAcesso = System.DateTime.Now;
            _context.TB_UTILIZADOR.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AlterarSenhaUsuarioAsync(UtilizadorModel credenciais)
        {
            UtilizadorModel usuario = await _context.TB_UTILIZADOR //Busca o usuário no banco através do login
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));


                Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                usuario.PasswordHash = hash; 
                usuario.PasswordSalt = salt; 

                _context.TB_UTILIZADOR.Update(usuario);
                await _context.SaveChangesAsync();
        }

        public async Task AlterarEmailUsuarioAsync(UtilizadorModel u)
        {
            UtilizadorModel usuario = await _context.TB_UTILIZADOR //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.IdUtilizador == u.IdUtilizador);

                usuario.Email = u.Email;                

                var attach = _context.Attach(usuario);
                attach.Property(x => x.IdUtilizador).IsModified = false;
                attach.Property(x => x.Email).IsModified = true;                

                await _context.SaveChangesAsync(); 
        }

    }
}