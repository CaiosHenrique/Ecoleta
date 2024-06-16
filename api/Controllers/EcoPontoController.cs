using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Services.EcoPonto;
using api.Repository.EcoPonto;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EcoPontoController : ControllerBase
    {
        private readonly List<EcopontoModel> ecoponto;
        private readonly DataContext _context;
        private readonly IEcoPontoService _ecoPontoService;
        private readonly IEcoPontoRepository _ecoPontoRepository;

        public EcoPontoController(DataContext context, IEcoPontoService ecoPontoService, IEcoPontoRepository ecoPontoRepository)
        {
            ecoponto = new List<EcopontoModel>();
            _context = context;
            _ecoPontoService = ecoPontoService;
            _ecoPontoRepository = ecoPontoRepository;

        }


        [HttpGet("GetbyId/{IdEcoponto}")]//Funcionando 200 Ok

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> GetEcoponto(int IdEcoponto)
        {
            try
            {
               
                var e = await _ecoPontoRepository.GetIdAsync(IdEcoponto);
                await _ecoPontoService.GetAsync(IdEcoponto);

                return StatusCode(200, e);

            }

            catch (Exception)
            {
                return StatusCode(404);

            }
            
        }

        [HttpGet("GetAll")]//Funcionando 200 Ok

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<EcopontoModel>>> GetAll()
        {
            try
            {
                var ecopontos =await  _ecoPontoRepository.GetAllAsync();
                return StatusCode(200, ecopontos);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

         [HttpPost("Post")]//Funcionando 200 Ok

         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]

         public async Task<ActionResult<EcopontoModel>> PostEcoPonto([FromBody] EcopontoModel ecoponto)
         {
            try
            {
                await _ecoPontoRepository.PostAsync(ecoponto);
                return StatusCode(201, ecoponto);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }

         }

        
        [HttpPut("Put/{IdEcoponto}")]//Funcionando 200 Ok

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Put(int id, EcopontoModel ecoponto)
        {
            try
            {
                await _ecoPontoRepository.PutAsync(id, ecoponto);
                return StatusCode(202);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }

        }
        


        
        [HttpDelete("Delete/{IdEcoponto}")] //Funcionando 200 Ok (:

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Delete(int IdEcoponto)
        {
            try
            {
                await _ecoPontoRepository.DeleteAsync(IdEcoponto);
                await _ecoPontoService.DeleteAsync(IdEcoponto);
                
                return StatusCode(200);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }
        }

        [HttpPost("CadastrarEcoponto")] //Não está funcionando 400 Bad Request ):

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegistrarEcoponto([FromBody] EcopontoModel ecoponto)
        {
            try
            {
                _ecoPontoRepository.LoginEcopontoAsync(ecoponto);

                return StatusCode(201, ecoponto);

            }

            catch (System.Exception ex)
            {
                return StatusCode(400, ex.Message);

            }
        }

        [HttpPost("AutenticarEcoponto")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult> AutenticarEcoponto([FromBody] EcopontoModel ecoponto)
    {
        try
        {
        
        
        _ecoPontoService.AutenticarEcoPontoAsync(ecoponto);
        _ecoPontoService.AutenticarTBEcoPontoAsync(ecoponto);
        _ecoPontoService.AutenticarSenhaEcoPonto(ecoponto);

        EcopontoModel EcoPonto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

        return StatusCode(200, EcoPonto);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


        [HttpPut("AlterarSenha")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> AlterarSenha([FromBody] EcopontoModel ecoponto)
    {
        try
        {

        _ecoPontoService.AutenticarEcoPontoAsync(ecoponto);

        _ecoPontoService.AutenticarTBEcoPontoAsync(ecoponto);

        _ecoPontoRepository.AlterarSenhaAsync(ecoponto);

        return StatusCode(200);
        }
        catch (System.Exception ex)
        {
        return StatusCode(500, ex.Message);
        }
    }   

    [HttpPut("AlterarEmail")]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult> AlterarEmail([FromBody] EcopontoModel ecoponto)
    {
        try
        {
            
        _ecoPontoService.AutenticarEcoPontoAsync(ecoponto);

        EcopontoModel EcoPonto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

        _ecoPontoService.AutenticarTBEcoPontoAsync(ecoponto);

        EcoPonto.Email = ecoponto.Email;

        _context.TB_ECOPONTO.Update(EcoPonto);
        await _context.SaveChangesAsync();

        return StatusCode(200, EcoPonto);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}
}
