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
        private readonly List<EcopontoModel> ecopontos;
        private readonly DataContext _context;

        public EcopontoController(DataContext context)
        {
            ecopontos = new List<EcopontoModel>();
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EcopontoModel>> Get()
        {
            return Ok(ecopontos);
        }

         [HttpPost]
        public ActionResult<EcopontoModel> Post([FromBody] EcopontoModel ecoponto)
        {
            ecoponto.Add(ecopontos);
            return CreatedAtAction(nameof(Get), new { id = ecoponto.IdEcoponto }, ecoponto);
        }

        // PUT: api/ecoponto/5
        [HttpPut("{id}")]
        public ActionResult<EcopontoModel> Put(int id, [FromBody] EcopontoModel ecoponto)
        {
            var index = ecopontos.FindIndex(p => p.IdEcoponto == id);
            if (index == -1)
            {
                return NotFound();
            }
            Ecopontoes[index] = ecoponto;
            return Ok(ecoponto);
        }

        // DELETE: api/ecoponto/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ecoponto = Ecopontos.Find(p => p.IdEcoponto == id);
            if (ecoponto == null)
            {
                return NotFound();
            }
            Ecopontoes.Remove(ecoponto);
            return NoContent();
        }
    }
}