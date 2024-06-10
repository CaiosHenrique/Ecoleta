using api.Data;
using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;

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
            return await _context.TB_UTILIZADOR.ToListAsync();
        }

        public async Task<UtilizadorModel> GetByIdAsync(int id)
        {
            return await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == id);
        }

        public async Task PostAsync(UtilizadorModel utilizador)
        {
            _context.TB_UTILIZADOR.Add(utilizador);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(int id, UtilizadorModel utilizador)
        {
            var existingUtilizador = await _context.TB_UTILIZADOR.FindAsync(id);

            _context.Entry(existingUtilizador).CurrentValues.SetValues(utilizador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var utilizador = await _context.TB_UTILIZADOR.FindAsync((UtilizadorModel u) => u.IdUtilizador == id);

            _context.TB_UTILIZADOR.Remove(utilizador);
            await _context.SaveChangesAsync();
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