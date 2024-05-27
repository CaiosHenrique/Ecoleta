using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using api.Data;

namespace Ecoleta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrindeController : ControllerBase
    {
          private readonly DataContext _context;
        private readonly ILogger<BrindeController> _logger;
        private readonly List<BrindeModel> _brindes;

        public BrindeController(ILogger<BrindeController> logger, DataContext context)
        {
            _logger = logger;
            _brindes = new List<BrindeModel>();
            _context = context;
        }

        // GET: api/Brinde
        [HttpGet]
        public ActionResult<IEnumerable<BrindeModel>> Get()
        {
            return Ok(_brindes);
        }

        // GET: api/Brinde/{id}
        [HttpGet("{id}")]
        public ActionResult<BrindeModel> Get(int id)
        {
            var brinde = _brindes.Find(b => b.IdBrinde == id);
            if (brinde == null)
            {
                return NotFound();
            }
            return Ok(brinde);
        }

        // POST: api/Brinde
        [HttpPost]
        public ActionResult<BrindeModel> Post(BrindeModel brinde)
        {
            brinde.IdBrinde = _brindes.Count + 1;
            _brindes.Add(brinde);
            _context.SaveChanges();
           
            return CreatedAtAction(nameof(Get), new { id = brinde.IdBrinde }, brinde);
        }

        // PUT: api/Brinde/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, BrindeModel updatedBrinde)
        {
            var brinde = _brindes.Find(b => b.IdBrinde == id);
            if (brinde == null)
            {
                return NotFound();
            }
            brinde.DescricaoBrinde = updatedBrinde.DescricaoBrinde;
            brinde.NomeBrinde = updatedBrinde.NomeBrinde;
            brinde.Cadastro = updatedBrinde.Cadastro;
            brinde.Validade = updatedBrinde.Validade;
            brinde.Quantidade = updatedBrinde.Quantidade;
            brinde.Saldo = updatedBrinde.Saldo;
            brinde.ValorEcopoints = updatedBrinde.ValorEcopoints;
             _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Brinde/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var brinde = _brindes.Find(b => b.IdBrinde == id);
            if (brinde == null)
            {
                return NotFound();
            }
            _brindes.Remove(brinde);
             _context.SaveChanges();
            return NoContent();
        }
    }
}