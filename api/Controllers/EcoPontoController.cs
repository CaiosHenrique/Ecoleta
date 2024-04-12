using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;

namespace api.Controllers
{
    public class EcoPontoController : ControllerBase
    {
        private readonly List<EcopontoModel> ecoponto;
        private readonly DataContext _context;

        public EcoPontoController(DataContext context)
        {
            ecoponto = new List<EcopontoModel>();
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetEcoponto(int IdEcoponto)
        {
           try
           {
                EcopontoModel e = await _context.TB_ECOPONTO.FindAsync(xEcoponto => xEcoponto.IdEcoponto == IdEcoponto);
                return Ok(e);
           }
              catch (System.Exception ex)
              {
                return BadRequest(ex.Message);
              }
            
        }

         [HttpPost]
         public async Task<ActionResult<EcopontoModel>> Post([FromBody] EcopontoModel ecoponto)
         {
            _context.TB_ECOPONTO.Add(ecoponto);
            await _context.SaveChangesAsync();
            return ecoponto;
          }

        // PUT: api/ecoponto/5
        [HttpPut("{IdEcoponto}")]
        public async Task<ActionResult> Update(EcopontoModel novoEcoPonto)
        {
            await _context.TB_ECOPONTO.AddAsync(novoEcoPonto);
            await _context.SaveChangesAsync();
            return Ok(novoEcoPonto.IdEcoponto);
            
        }

        // DELETE: api/ecoponto/5
        [HttpDelete("{IdEcoponto}")]
        public async Task<ActionResult> Delete(int IdEcoponto)
        {
            EcopontoModel ecoponto = await _context.TB_ECOPONTO.FindAsync(x => x.IdEcoponto == IdEcoponto);
            _context.TB_ECOPONTO.Remove(ecoponto);
            int linhasAfetadas = await _context.SaveChangesAsync();
            return Ok(linhasAfetadas);
        }
    }
}