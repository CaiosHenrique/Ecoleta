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
            var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == id);
            _context.TB_UTILIZADOR.Remove(utilizador);
            await _context.SaveChangesAsync();

            return utilizador;
        }

        public async Task RegistrarUsuarioAsync(string username, string passwordString)
        {
            Criptografia.CriarPasswordHash(passwordString, out byte[] hash, out byte[] salt);

                UtilizadorModel utilizador = new UtilizadorModel
            {
                Username = username,
                PasswordString = string.Empty, // A senha em texto claro não é armazenada
                PasswordHash = hash,
                PasswordSalt = salt
            };

                await _context.TB_UTILIZADOR.AddAsync(utilizador);
                await _context.SaveChangesAsync();
        }

        public async Task<bool> AutenticarUsuarioAsync(string username, string passwordString)
        {
            UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

            if (usuario != null)
            {
             // Verifica se a senha fornecida, após ser criptografada, corresponde ao hash armazenado
            bool senhaValida = Criptografia.VerificarPasswordHash(passwordString, usuario.PasswordHash, usuario.PasswordSalt);

             if (senhaValida)
            {
            // Atualiza a DataAcesso do usuário para agora, indicando um login bem-sucedido
            usuario.DataAcesso = System.DateTime.Now;
            _context.TB_UTILIZADOR.Update(usuario);
            await _context.SaveChangesAsync();

            return true; // Autenticação bem-sucedida
            }
            }

             return false; // Autenticação falhou
            }

           public async Task AlterarSenhaUsuarioAsync(string username, string novaSenha)
{   
        UtilizadorModel usuario = await _context.TB_UTILIZADOR
            .FirstOrDefaultAsync(x => x.Username == username);

        // Cria um novo hash de senha e sal com a nova senha fornecida
        Criptografia.CriarPasswordHash(novaSenha, out byte[] novoHash, out byte[] novoSal);

        // Atualiza o hash de senha e sal do usuário
        usuario.PasswordHash = novoHash;
        usuario.PasswordSalt = novoSal;

        // Marca as propriedades PasswordHash e PasswordSalt como modificadas
        var attach = _context.Attach(usuario);
        attach.Property(x => x.PasswordHash).IsModified = true;
        attach.Property(x => x.PasswordSalt).IsModified = true;

        // Salva as alterações no banco de dados
        await _context.SaveChangesAsync();
}

        public async Task AlterarEmailUsuarioAsync(int idUtilizador, string email)
        {
         UtilizadorModel usuario = await _context.TB_UTILIZADOR
           .FirstOrDefaultAsync(x => x.IdUtilizador == idUtilizador);

    
        usuario.Email = email;

        var attach = _context.Attach(usuario);
        attach.Property(x => x.Email).IsModified = true;

        await _context.SaveChangesAsync();
        }

        public async Task<string> ResgatarBrindeAsync(int idUtilizador, int idBrinde)
{
    var usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == idUtilizador);
    var brinde = await _context.TB_BRINDE.FirstOrDefaultAsync(b => b.IdBrinde == idBrinde);

    if (usuario == null || brinde == null)
    {
        return "Usuário ou brinde não encontrado.";
    }

    if (usuario.TotalEcoPoints >= brinde.ValorEcopoints)
    {
        // Subtrai os pontos do usuário
        usuario.TotalEcoPoints -= brinde.ValorEcopoints;
        
        // Diminui a quantidade disponível do brinde
        brinde.Quantidade-= 1;

        // Verifica se ainda há brindes disponíveis
        if (brinde.Quantidade < 0)
        {
            return "Brinde não está mais disponível.";
        }

        // Atualiza o usuário e o brinde no contexto
        _context.TB_UTILIZADOR.Update(usuario);
        _context.TB_BRINDE.Update(brinde);


        var resgate = new ResgateModel
        {
            IdUtilizador = idUtilizador,
            IdBrinde = idBrinde,
            DataResgate = DateTime.Now
        };
        _context.TB_RESGATE.Add(resgate);

        await _context.SaveChangesAsync();

        string codigoCupom = Guid.NewGuid().ToString();
        return $"Código do cupom: {codigoCupom}";
    }
    else
    {
        return "Pontos insuficientes para resgatar o brinde.";
    }
}

    }
}