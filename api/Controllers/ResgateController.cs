using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Services.Resgate;
using api.Repository.Resgate;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResgateController : ControllerBase
    {
        private readonly IResgateService _resgateService;
        private readonly IResgateRepository _resgateRepository;

        private readonly DataContext _context;

        public ResgateController(DataContext context, IResgateService resgateService, IResgateRepository resgateRepository)
        {
            _context = context;
            _resgateService = resgateService;
            _resgateRepository = resgateRepository;
        }

        [HttpGet("GetAll")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ResgateModel>> GetAll()
        {
            try
            {
                var resgates = await _resgateRepository.GetAllAsync();
                return StatusCode(200, resgates);

            }

            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetbyId")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<ResgateModel>> Get(int IdBrinde, int IdUtilizador)
        {
            try
            {
                var resgate = await _resgateRepository.GetByBrindeIdForUserAsync(IdBrinde, IdUtilizador);

                await _resgateService.GetAsync(IdBrinde);

                return Ok(resgate);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}