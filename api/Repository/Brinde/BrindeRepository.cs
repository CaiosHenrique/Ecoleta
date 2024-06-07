using api.Models;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Repository.Brinde
{
    public class BrindeRepository : IBrindeRepository
    {

        private readonly DataContext _context;
        public BrindeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BrindeModel>> GetAllAsync()
        {
            var brinde = _context.TB_BRINDE.ToList();
            return brinde;
        }

        public async Task<ActionResult<BrindeModel>> GetIdAsync(int id)
        {
            var brinde = _context.TB_BRINDE.Find((BrindeModel b) => b.IdBrinde == id);
            return brinde;
        }
        
        public async Task<ActionResult<BrindeModel>> PostAsync(BrindeModel brinde)
        {
            brinde.IdBrinde = _context.TB_BRINDE.Count() + 1;

            _context.TB_BRINDE.Add(brinde);
           
           await _context.SaveChangesAsync();

           return brinde;
        }

        public async Task<IActionResult> PutAsync(int id, BrindeModel updatedBrinde)
        {
            var brinde = _context.TB_BRINDE.Find((BrindeModel b) => b.IdBrinde == id);


            brinde.DescricaoBrinde = updatedBrinde.DescricaoBrinde;
            brinde.NomeBrinde = updatedBrinde.NomeBrinde;
            brinde.Cadastro = updatedBrinde.Cadastro;
            brinde.Validade = updatedBrinde.Validade;
            brinde.Quantidade = updatedBrinde.Quantidade;
            brinde.Saldo = updatedBrinde.Saldo;
            brinde.ValorEcopoints = updatedBrinde.ValorEcopoints;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}