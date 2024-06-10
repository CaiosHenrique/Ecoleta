using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using api.Services.EcoPoints;
using api.Services.Utilizador;
using api.Repository.EcoPoints;


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
        private readonly IEcoPointsService _ecoPointsService;
        private readonly EcoPointsRepository _ecoPointsRepository;
       
        
        
        


        public EcoPointsController(DataContext context, UtilizadorService utilizadorService, IEcoPointsService ecoPointsService, EcoPointsRepository ecoPointsRepository)
        {
            _context = context;
            ecopoints = new List<EcopointsModel>();
            utilizador = new List<UtilizadorModel>();
            _utilizadorService = new UtilizadorService(context);
            _ecoPointsService = ecoPointsService;
            _ecoPointsRepository = ecoPointsRepository;
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
                var ecopoints = _ecoPointsRepository.GetIdMaterialAsync(IdMaterial);

                _ecoPointsService.GetMaterial(IdMaterial);

                return StatusCode(200, ecopoints);

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

        public async Task<ActionResult<int>> GetEcopointsUtilizador(int IdUtilizador)
        {
            try
            {
                var utilizador = await _ecoPointsRepository.GetIdUtilizadorAsync(IdUtilizador);

                _ecoPointsService.GetUtilizador(IdUtilizador);

                // Retorne o total de EcoPoints do usuário
                return utilizador;

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

        public ActionResult<IEnumerable<EcopointsModel>> GetAll()
        {
            try
            {
                var ecopoints = _ecoPointsRepository.GetAllAsync();
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
                _ecoPointsRepository.PostAsync(ecopoint);

                _utilizadorService.AddEcoPoints(IdUtilizador, quantidade);

                _context.SaveChanges();

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
                
                _ecoPointsService.PutAsync(IdUtilizador);
                _ecoPointsRepository.PutAsync(ecopoint, IdUtilizador);
                
               
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
                

                _ecoPointsService.DeleteAsync(IdUtilizador);

                _ecoPointsRepository.DeleteAsync(IdUtilizador);
                

                
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