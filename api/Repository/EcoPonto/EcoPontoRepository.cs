using api.Data;
using api.Models;
using api.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.EcoPonto
{
    public class EcoPontoRepository : IEcoPontoRepository
    {
        private readonly DataContext _context;

        public EcoPontoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<EcopontoModel>> GetIdAsync(int IdEcoponto)
        {
            var ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(e => e.IdEcoponto == IdEcoponto);
            return ecoponto;
        }

        public async Task<List<EcopontoModel>> GetAllAsync()
        {
            var ecopontos = await _context.TB_ECOPONTO.ToListAsync();
            return ecopontos;
        }

        public async Task<ActionResult<EcopontoModel>> PostAsync(EcopontoModel ecoponto)
        {
            ecoponto.IdEcoponto = 0;

            _context.TB_ECOPONTO.AddAsync(ecoponto);
            await _context.SaveChangesAsync();
            return ecoponto;
        }

        public async Task<ActionResult<EcopontoModel>> PutAsync(string username, EcopontoModel ecoponto)
        {
            var ecopontoexistente = await _context.TB_ECOPONTO.FirstOrDefaultAsync(e => e.Username == username);

            ecopontoexistente.Nome = ecoponto.Nome;
            ecopontoexistente.CNPJ = ecoponto.CNPJ;
            ecopontoexistente.RazaoSocial = ecoponto.RazaoSocial;
            ecopontoexistente.Logradouro = ecoponto.Logradouro;
            ecopontoexistente.Endereco = ecoponto.Endereco;
            ecopontoexistente.Complemento = ecoponto.Complemento;
            ecopontoexistente.Bairro = ecoponto.Bairro;
            ecopontoexistente.Cidade = ecoponto.Cidade;
            ecopontoexistente.UF = ecoponto.UF;
            ecopontoexistente.Numero = ecoponto.Numero;
            ecopontoexistente.CEP = ecoponto.CEP;


            await _context.SaveChangesAsync();
            return ecopontoexistente;
        }

        public async Task<ActionResult<EcopontoModel>> DeleteAsync(int IdEcoponto)
        {
            var ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync((EcopontoModel e) => e.IdEcoponto == IdEcoponto);
            _context.TB_ECOPONTO.Remove(ecoponto);
            await _context.SaveChangesAsync();
            return ecoponto;
        }

        public async Task RegistrarEcopontoAsync(string username, string passwordString)
        {
            Criptografia.CriarPasswordHash(passwordString, out byte[] hash, out byte[] salt);

                EcopontoModel ecoponto = new EcopontoModel
            {
                Username = username,
                PasswordString = string.Empty, 
                PasswordHash = hash,
                PasswordSalt = salt
            };

                await _context.TB_ECOPONTO.AddAsync(ecoponto);
                await _context.SaveChangesAsync();
        }

        public async Task<bool> AutenticarEcopontoAsync(string username, string passwordString)
        {
            EcopontoModel? ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

            if (ecoponto != null)
            {
             
            bool senhaValida = Criptografia.VerificarPasswordHash(passwordString, ecoponto.PasswordHash, ecoponto.PasswordSalt);

             if (senhaValida)
            {
            

            _context.TB_ECOPONTO.Update(ecoponto);
            await _context.SaveChangesAsync();

            return true; 
            }
            }

             return false; 
            }

        public async Task AlterarSenhaEcopontoAsync(string username, string novaSenha)
{   
        EcopontoModel ecoponto = await _context.TB_ECOPONTO
            .FirstOrDefaultAsync(x => x.Username == username);

        Criptografia.CriarPasswordHash(novaSenha, out byte[] novoHash, out byte[] novoSal);

        ecoponto.PasswordHash = novoHash;
        ecoponto.PasswordSalt = novoSal;

        var attach = _context.Attach(ecoponto);
        attach.Property(x => x.PasswordHash).IsModified = true;
        attach.Property(x => x.PasswordSalt).IsModified = true;

        await _context.SaveChangesAsync();
}

        public async Task AlterarEmailEcopontoAsync(string username, string email)
        {
         EcopontoModel ecoponto = await _context.TB_ECOPONTO
           .FirstOrDefaultAsync(x => x.Username == username);

    
        ecoponto.Email = email;

        var attach = _context.Attach(ecoponto);
        attach.Property(x => x.Email).IsModified = true;

        await _context.SaveChangesAsync();
        }
       
    }
}