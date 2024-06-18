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

        
        private readonly IUtilizadorService _utilizadorService;
        private readonly IUtilizadorRepository _utilizadorRepository;

        private readonly DataContext _context;

        public UtilizadorController(DataContext context, IUtilizadorService utilizadorService, IUtilizadorRepository utilizadorRepository)
        {
            
            _context = context;
            _utilizadorService = utilizadorService;
            _utilizadorRepository = utilizadorRepository;
        }

        
        [HttpGet("GetAll")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<UtilizadorModel>> GetAll()
        {
            try
            {
                var utilizadores = await _utilizadorRepository.GetAllAsync();
                return StatusCode(200, utilizadores);

            }

            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        [HttpGet("GetbyId/{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<UtilizadorModel>> Get(int id)
        {
            try
            {
                var utilizador = await _utilizadorRepository.GetByIdAsync(id);

                await _utilizadorService.GetAsync(id);

                return Ok(utilizador);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }
        }

        
        [HttpPost("Post")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<ActionResult<UtilizadorModel>> Post([FromBody] UtilizadorModel utilizador)
        {
            try
            {
                var novoUtilizador = await _utilizadorRepository.PostAsync(utilizador);
                return StatusCode(201, novoUtilizador);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        
        [HttpPut("Put/{id}")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

                public async Task<ActionResult<UtilizadorModel>> Put(int id, [FromBody] UtilizadorModel utilizador)
                {       
                try
                {
                    await _utilizadorService.PutAsync(id);

                    await _utilizadorRepository.PutAsync(id, utilizador);

                    return Ok("Utilizador Atualizado com sucesso!");
                }
                catch (System.Exception)
                {
                    return StatusCode(500);
                }
                }       

        
        [HttpDelete("Delete/{id}")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _utilizadorService.DeleteAsync(id);
                await _utilizadorRepository.DeleteAsync(id);

            return Ok("Utilizador Deletado com sucesso!");

            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }


        

        [HttpPost("Registrar")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarUsuario(string username, string passwordString)
        {
            try
            {
                await _utilizadorService.RegistrarUserExistente(username);

                await _utilizadorRepository.RegistrarUsuarioAsync(username, passwordString);

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
        public async Task<IActionResult> AutenticarUsuario(string username, string passwordString)
        {
            try
            {
                await _utilizadorService.RegistrarUserExistente(username);
                await _utilizadorRepository.AutenticarUsuarioAsync(username, passwordString);

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
                await _utilizadorService.GetUserAsync(credenciais);
                await _utilizadorRepository.AlterarSenhaUsuarioAsync(credenciais);
                 
                return Ok(200); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarEmail")]
        public async Task<IActionResult> AtualizarEmail(int idUtilizador, string email)
        {
            try
            {
                await _utilizadorRepository.AlterarEmailUsuarioAsync(idUtilizador, email);
                
                return Ok("Email atualizado com sucesso!"); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    [HttpPost("ResgatarBrinde/{idUtilizador}/{idBrinde}")]
    public async Task<IActionResult> ResgatarBrinde(int idUtilizador, int idBrinde)
{
    try
    {
    var resultado = await _utilizadorRepository.ResgatarBrindeAsync(idUtilizador, idBrinde);

    return Ok(resultado);
    }
    catch (System.Exception ex)
    {
        return BadRequest(ex.Message);
    }

}
}
}
