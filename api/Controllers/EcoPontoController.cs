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
    [ApiController]
    [Route("api/[controller]")]
    public class EcoPontoController : ControllerBase
    {
        private readonly List<EcopontoModel> ecoponto;
        private readonly DataContext _context;

        public EcoPontoController(DataContext context)
        {
            ecoponto = new List<EcopontoModel>();
            _context = context;

        }


        [HttpGet("{IdEcoponto}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> GetEcoponto(int IdEcoponto)
        {
            try
            {
                EcopontoModel e = await _context.TB_ECOPONTO.FindAsync(IdEcoponto);
                return StatusCode(200, e);

            }

            catch (Exception)
            {
                return StatusCode(404);

            }
            
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<EcopontoModel>>> GetAll()
        {
            try
            {
                var ecopontos = _context.TB_ECOPONTO.ToList();
                return StatusCode(200, ecopontos);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

         [HttpPost]

         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]

         public async Task<ActionResult<EcopontoModel>> PostEcoPonto([FromBody] EcopontoModel ecoponto)
         {
            try
            {
                await _context.TB_ECOPONTO.AddAsync(ecoponto);
                await _context.SaveChangesAsync();
                return StatusCode(201, ecoponto);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }

         }

        
        [HttpPut("{IdEcoponto}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Update(EcopontoModel novoEcoPonto)
        {
            try
            {
                await _context.TB_ECOPONTO.AddAsync(novoEcoPonto);
                await _context.SaveChangesAsync();
                return StatusCode(200, novoEcoPonto);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }

        }
        


        
        [HttpDelete("{IdEcoponto}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int IdEcoponto)
        {
            try
            {
                EcopontoModel ecoponto = await _context.TB_ECOPONTO.FindAsync(IdEcoponto);
                _context.TB_ECOPONTO.Remove(ecoponto);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return StatusCode(200, linhasAfetadas);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }
        }
    }
}
