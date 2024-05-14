using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;
using api.Utils;

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

        [HttpPost("CadastrarEcoponto")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RegistrarEcoponto([FromBody] EcopontoModel ecoponto)
        {
            try
            {
                Criptografia.CriarPasswordHash(utilizador.PasswordString, out byte[] hash, out byte[] salt);

                ecoponto.PasswordString = string.Empty;
                ecoponto.PasswordHash = hash;
                ecoponto.PasswordSalt = salt;

                await _context.TB_ECOPONTO.AddAsync(ecoponto);
                await _context.SaveChangesAsync();

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
                EcopontoModel ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

                if (ecoponto == null)
                    return StatusCode(404);

                if (!Criptografia.VerificarPasswordHash(ecoponto.PasswordHash, ecoponto.PasswordSalt, ecoponto.PasswordString))
                    return StatusCode(401);

                return StatusCode(200, ecoponto);

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
                EcopontoModel ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

                if (ecoponto == null)
                    return StatusCode(404);

                Criptografia.CriarPasswordHash(ecoponto.PasswordString, out byte[] hash, out byte[] salt);

                ecoponto.PasswordString = string.Empty;
                ecoponto.PasswordHash = hash;
                ecoponto.PasswordSalt = salt;

                await _context.SaveChangesAsync();

                return StatusCode(200, ecoponto);

            }

            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpPut("AlterarEmail")]
        public async Task<ActionResult> AlterarEmail([FromBody] EcopontoModel ecoponto)
        {
            try
            {
                EcopontoModel ecoponto = await _context.TB_ECOPONTO.FirstOrDefaultAsync(x => x.Username == ecoponto.Username);

                if (ecoponto == null)
                    return StatusCode(404);

                ecoponto.Email = ecoponto.Email;

                await _context.SaveChangesAsync();

                return StatusCode(200, ecoponto);

            }

            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

    }
}
