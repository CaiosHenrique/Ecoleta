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
            await _brindeService.PutAsync(id);
            await _brindeRepository.PutAsync(id, updatedBrinde);
            
            
            return Ok("Brinde Atualizado com sucesso!");
        }

        // DELETE: api/Brinde/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _brindeService.DeleteAsync(id);
            await _brindeRepository.DeleteAsync(id);
            
            return Ok("Brinde Deletado com sucesso!");
        }
    }
}