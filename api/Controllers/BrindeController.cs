using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using api.Data;
using api.Services.Brinde;

namespace Ecoleta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrindeController : ControllerBase
    {
        
        private readonly ILogger<BrindeController> _logger;
        private readonly DataContext _context;
        private readonly IBrindeService _brindeService;

        public BrindeController(ILogger<BrindeController> logger, IBrindeService BrindeService, DataContext context)
        {
            _logger = logger;
            _brindeService = BrindeService;
            _context = context;
           
        }

        // GET: api/Brinde
        [HttpGet]
        public ActionResult<IEnumerable<BrindeModel>> Get()
        {
            var brinde = _context.TB_BRINDE.ToList();
            return Ok(brinde);
        }

        // GET: api/Brinde/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BrindeModel>> Get(int id)
        {
            var brinde = _context.TB_BRINDE.Find((BrindeModel b) => b.IdBrinde == id);

            await _brindeService.GetAsync(id);
            
            return Ok(brinde);
        }

        // POST: api/Brinde
        [HttpPost]
        public async Task<ActionResult<BrindeModel>> Post(BrindeModel brinde)
        {
            brinde.IdBrinde = _context.TB_BRINDE.Count() + 1;

            _context.TB_BRINDE.Add(brinde);
           
           await _context.SaveChangesAsync();
           
            return CreatedAtAction(nameof(Get), new { id = brinde.IdBrinde }, brinde);
        }

        // PUT: api/Brinde/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BrindeModel updatedBrinde)
        {
            var brinde = _context.TB_BRINDE.Find((BrindeModel b) => b.IdBrinde == id);
            

            _brindeService.PutAsync(id);

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

        // DELETE: api/Brinde/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brinde = _context.TB_BRINDE.Find((BrindeModel b) => b.IdBrinde == id);
            
            _brindeService.DeleteAsync(id);

            _context.TB_BRINDE.Remove(brinde);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}