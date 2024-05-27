using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EcoPointsController : ControllerBase
    {
        private readonly List<EcopointsModel> ecopoints;
        private readonly DataContext _context;
        private readonly List<UtilizadorModel> utilizador;
        private readonly UtilizadorService _utilizadorService;


        public EcoPointsController(DataContext context)
        {
            _context = context;
            ecopoints = new List<EcopointsModel>();
            utilizador = new List<UtilizadorModel>();
            _utilizadorService = new UtilizadorService(context);
        }


        // GET: api/EcoPoints/5
        [HttpGet("{IdMaterial}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<EcopointsModel> Get(int IdMaterial)
        {
            try
            {
                var ecopoint = ecopoints.Find(e => e.IdMaterial == IdMaterial);

                if (ecopoint == null)
                {
                    return StatusCode(404);

                }

                return StatusCode(200, ecopoint);

            }
            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        [HttpGet("{IdUtilizador}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<int> GetEcopointsUtilizador(int IdUtilizador)
        {
            try
            {
                var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

                // Verifique se o usuário existe
                if (utilizador == null)
                {
                    return NotFound();
                }

                // Retorne o total de EcoPoints do usuário
                return utilizador.TotalEcoPoints;

            }
            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        // GET: api/EcoPoints
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<UtilizadorModel>> GetAll()
        {
            try
            {
                var ecopoints = _context.TB_ECOPOINTS.ToList();
                return StatusCode(200, ecopoints);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        // POST: api/EcoPoints
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<EcopointsModel> Post([FromBody] EcopointsModel ecopoint, int IdUtilizador, int quantidade)
        {
            try
            {
                ecopoints.Add(ecopoint);

                _utilizadorService.AddEcoPoints(IdUtilizador, quantidade);

                return StatusCode(201, ecopoint);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }

        }

        // PUT: api/EcoPoints/5
        // PUT: api/EcoPoints/{IdUtilizador}
        [HttpPut("{IdUtilizador}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EcopointsModel> Put(int IdUtilizador, [FromBody] EcopointsModel ecopoint)
        {
            try
            {
                // Busque o usuário pelo ID
                var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

                // Verifique se o usuário existe
                if (utilizador == null)
                {
                    return StatusCode(404);
                }

                // Atualize os EcoPoints do usuário
                utilizador.TotalEcoPoints = ecopoint.TotalEcoPoints;

                // Salve as alterações no banco de dados
                _context.SaveChanges();

                return StatusCode(200, ecopoint);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/EcoPoints/5
        // DELETE: api/EcoPoints/{IdUtilizador}
        [HttpDelete("{IdUtilizador}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int IdUtilizador)
        {
            try
            {
                // Busque o usuário pelo ID
                var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

                // Verifique se o usuário existe
                if (utilizador == null)
                {
                    return StatusCode(404);
                }

                // Defina os EcoPoints do usuário como 0
                utilizador.TotalEcoPoints = 0;

                // Salve as alterações no banco de dados
                _context.SaveChanges();

                return StatusCode(200);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}