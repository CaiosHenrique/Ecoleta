using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using api.Data;
using api.Services.Brinde;
using api.Repository.Brinde;

namespace Ecoleta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrindeController : ControllerBase
    {
        
        private readonly ILogger<BrindeController> _logger;
        private readonly DataContext _context;
        private readonly IBrindeService _brindeService;
        private readonly IBrindeRepository _brindeRepository;

        public BrindeController(ILogger<BrindeController> logger, IBrindeService BrindeService, DataContext context, IBrindeRepository BrindeRepository)
        {
            _logger = logger;
            _brindeService = BrindeService;
            _context = context;
            _brindeRepository = BrindeRepository;
           
        }

        // GET: api/Brinde
        [HttpGet]
        public ActionResult<IEnumerable<BrindeModel>> Get()
        {
            var brindes = _brindeRepository.GetAllAsync();
            return Ok(brindes);
        }

        // GET: api/Brinde/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BrindeModel>> GetId(int id)
        {
           
           
            await _brindeService.GetAsync(id);
            var brinde = await _brindeRepository.GetIdAsync(id);
            
            return Ok(brinde);
        }

        // POST: api/Brinde
        [HttpPost]
        public async Task<ActionResult<BrindeModel>> Post(BrindeModel brinde)
        {
            
            var newBrinde = _brindeRepository.PostAsync(brinde);
            return Ok(newBrinde);
            
        }

        // PUT: api/Brinde/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BrindeModel updatedBrinde)
        {
            _brindeService.PutAsync(id);
            _brindeRepository.PutAsync(id, updatedBrinde);
            
            
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