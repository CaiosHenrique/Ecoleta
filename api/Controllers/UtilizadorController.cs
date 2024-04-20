using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly List<UtilizadorModel> utilizadores;
        private readonly DataContext _context;

        public UtilizadorController(DataContext context)
        {
            utilizadores = new List<UtilizadorModel>();
            _context = context;
        }

        // GET: api/Utilizador
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UtilizadorModel>> GetAll()
        {
            try
            {
                var utilizadores = _context.TB_UTILIZADOR.ToList();
                return StatusCode(200, utilizadores);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Utilizador/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UtilizadorModel> Get(int id)
        {
            var utilizador = utilizadores.Find(u => u.IdUtilizador == id);
            if (utilizador == null)
            {
                return StatusCode(404);
            }
            return Ok(utilizador);
        }

        // POST: api/Utilizador
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<UtilizadorModel> Post([FromBody] UtilizadorModel utilizador)
        {
            try
            {
                utilizadores.Add(utilizador);
                return StatusCode(201, utilizador);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Utilizador/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UtilizadorModel> Put(int id, [FromBody] UtilizadorModel utilizador)
        {
            try
            {
            var index = utilizadores.FindIndex(u => u.IdUtilizador == id);
            if (index == -1)
            {
                return StatusCode(404);
            }

            utilizadores[index] = utilizador;
            return StatusCode(202, utilizador);

            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/Utilizador/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try{
            var utilizador = utilizadores.Find(u => u.IdUtilizador == id);
            if (utilizador == null)
            {
                return StatusCode(404);
            }

            utilizadores.Remove(utilizador);
            return StatusCode(200);

            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
