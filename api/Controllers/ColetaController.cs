using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;
using api.Services.Coleta;
using api.Repository.Coleta;

namespace api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ColetaController : ControllerBase
    {
        
    private readonly DataContext _context;
    private readonly List<ColetaModel> coletas;
    private readonly IColetaService _coletaService;
    private readonly IColetaRepository _coletaRepository;

        public ColetaController(DataContext context, IColetaService ColetaService, IColetaRepository ColetaRepository)
        {
            coletas = new List<ColetaModel>();
            _context = context;
            _coletaService = ColetaService;
            _coletaRepository = ColetaRepository;
        }

        [HttpGet("GetAll")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<ColetaModel>>> GetAll()
        {
            try
            {
                var coletas = await _coletaRepository.GetAllAsync();
                return Ok(coletas);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
       
        [HttpGet("GetId/{IdColeta}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ColetaModel>> GetId(int IdColeta)
        {
            try
            {

                await _coletaService.GetAsync(IdColeta);
                var coleta = await _coletaRepository.GetIdAsync(IdColeta);


               
                return Ok(coleta);

            }

            catch (System.Exception)
            {
                    return StatusCode(500);

            }

        }

        [HttpPost("Post")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ColetaModel>> PostColeta([FromBody] ColetaModel coleta)
        {
            try
            {
                var Coleta = await _coletaRepository.PostAsync(coleta);
                return StatusCode(201, Coleta);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        [HttpPut("Put/{IdColeta}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ColetaModel>> PutColeta(int IdColeta, ColetaModel coleta)
        {
            try
            {

                var coletaAtual = await _coletaRepository.PutAsync(IdColeta, coleta);
                await _coletaService.PutAsync(IdColeta);

                return Ok(coletaAtual);

            }

            catch (System.Exception)
            {
                return StatusCode(400);

            }

        }

        [HttpDelete("Delete/{IdColeta}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ColetaModel>> Delete(int IdColeta)
        {
            try
            {
                var coleta = await _coletaRepository.DeleteAsync(IdColeta);
                await _coletaService.DeleteAsync(IdColeta);


                return Ok(coleta);

            }
            catch (System.Exception)
            {
                return StatusCode(500);

            }
        }
    }
}