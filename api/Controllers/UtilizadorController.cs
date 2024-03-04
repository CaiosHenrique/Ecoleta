using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly List<UtilizadorModel> utilizadores;

        public UtilizadorController()
        {
            utilizadores = new List<UtilizadorModel>();
        }

        // GET: api/Utilizador
        [HttpGet]
        public ActionResult<IEnumerable<UtilizadorModel>> Get()
        {
            return Ok(utilizadores);
        }

        // GET: api/Utilizador/5
        [HttpGet("{id}")]
        public ActionResult<UtilizadorModel> Get(int id)
        {
            var utilizador = utilizadores.Find(u => u.IdUtilizador == id);
            if (utilizador == null)
            {
                return NotFound();
            }
            return Ok(utilizador);
        }

        // POST: api/Utilizador
        [HttpPost]
        public ActionResult<UtilizadorModel> Post([FromBody] UtilizadorModel utilizador)
        {
            utilizadores.Add(utilizador);
            return CreatedAtAction(nameof(Get), new { id = utilizador.IdUtilizador }, utilizador);
        }

        // PUT: api/Utilizador/5
        [HttpPut("{id}")]
        public ActionResult<UtilizadorModel> Put(int id, [FromBody] UtilizadorModel utilizador)
        {
            var index = utilizadores.FindIndex(u => u.IdUtilizador == id);
            if (index == -1)
            {
                return NotFound();
            }
            utilizadores[index] = utilizador;
            return Ok(utilizador);
        }

        // DELETE: api/Utilizador/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var utilizador = utilizadores.Find(u => u.IdUtilizador == id);
            if (utilizador == null)
            {
                return NotFound();
            }
            utilizadores.Remove(utilizador);
            return NoContent();
        }
    }
}
