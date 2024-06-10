using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Utils;
using api.Services.Utilizador;
using api.Repository.Utilizador;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {

        private readonly List<UtilizadorModel> utilizadores;
        private readonly IUtilizadorService _utilizadorService;
        private readonly IUtilizadorRepository _utilizadorRepository;

        private readonly DataContext _context;

        public UtilizadorController(DataContext context, IUtilizadorService utilizadorService, IUtilizadorRepository utilizadorRepository)
        {
            utilizadores = new List<UtilizadorModel>();
            _context = context;
            _utilizadorService = utilizadorService;
            _utilizadorRepository = utilizadorRepository;
        }

        
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<UtilizadorModel>> GetAll()
        {
            try
            {
                var utilizadores = _utilizadorRepository.GetAllAsync();
                return StatusCode(200, utilizadores);

            }

            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<UtilizadorModel>> Get(int id)
        {
            try
            {
                var utilizador = _utilizadorRepository.GetByIdAsync(id);

                _utilizadorService.GetAsync(id);

                return Ok(utilizador);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }
        }

        
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<UtilizadorModel> Post([FromBody] UtilizadorModel utilizador)
        {
            try
            {
                var novoUtilizador = _utilizadorRepository.PostAsync(utilizador);
                return StatusCode(201, utilizador);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        
        [HttpPut("{id}")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

                public async Task<ActionResult<UtilizadorModel>> Put(int id, [FromBody] UtilizadorModel utilizador)
                {       
                try
                {
                    _utilizadorService.PutAsync(id);
                    _utilizadorRepository.PutAsync(id, utilizador);

                    return AcceptedAtAction(nameof(Get), new { id = utilizador.IdUtilizador }, utilizador);
                }
                catch (System.Exception)
                {
                    return StatusCode(500);
                }
                }       

        
        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult Delete(int id)
        {
            try
            {
                _utilizadorService.DeleteAsync(id);
                _utilizadorRepository.DeleteAsync(id);

            return StatusCode(200);

            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }


        

        [HttpPost("Registrar")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarUsuario(UtilizadorModel utilizador)
        {
            try
            {
                _utilizadorService.RegistrarUserExistente(utilizador);

                _utilizadorRepository.RegistrarUsuarioAsync(utilizador);

                return StatusCode(200);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AutenticarUsuario(UtilizadorModel credenciais)
        {
            try
            {
                _utilizadorService.AutenticarUsuarioAsync(credenciais);
                _utilizadorRepository.AutenticarUsuarioAsync(credenciais);

                    return StatusCode(200);
                
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaUsuario(UtilizadorModel credenciais)
        {
            try
            {
                _utilizadorService.GetUserAsync(credenciais);
                _utilizadorRepository.AlterarSenhaUsuarioAsync(credenciais);
                 
                return Ok(200); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(UtilizadorModel u)
        {
            try
            {
                _utilizadorRepository.AlterarEmailUsuarioAsync(u);
                
                return Ok(200); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
