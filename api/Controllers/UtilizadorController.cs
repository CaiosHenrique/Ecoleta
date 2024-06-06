using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Utils;
using api.Services.Utilizador;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {

        private readonly List<UtilizadorModel> utilizadores;
        private readonly IUtilizadorService _utilizadorService;

        private readonly DataContext _context;

        public UtilizadorController(DataContext context, IUtilizadorService utilizadorService)
        {
            utilizadores = new List<UtilizadorModel>();
            _context = context;
            _utilizadorService = utilizadorService;
        }

        
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
                var utilizador = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(u => u.IdUtilizador == id);

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
                _context.TB_UTILIZADOR.Add(utilizador);
                _context.SaveChanges();
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
                    var existingUtilizador = await _context.TB_UTILIZADOR.FindAsync(id);

                    _utilizadorService.PutAsync(id);

                    _context.Entry(existingUtilizador).CurrentValues.SetValues(utilizador);
                    await _context.SaveChangesAsync();

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
                var utilizador = _context.TB_UTILIZADOR.Find((UtilizadorModel u) => u.IdUtilizador == id);

                _utilizadorService.DeleteAsync(id);

            _context.TB_UTILIZADOR.Remove(utilizador);
            _context.SaveChanges();
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

                Criptografia.CriarPasswordHash(utilizador.PasswordString, out byte[] hash, out byte[] salt);

                utilizador.PasswordString = string.Empty;
                utilizador.PasswordHash = hash;
                utilizador.PasswordSalt = salt;

                await _context.TB_UTILIZADOR.AddAsync(utilizador);
                await _context.SaveChangesAsync();

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

                UtilizadorModel? usuario = await _context.TB_UTILIZADOR.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));
                   
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.TB_UTILIZADOR.Update(usuario);
                    await _context.SaveChangesAsync(); //Confirma a alteração no banco

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
                UtilizadorModel usuario = await _context.TB_UTILIZADOR //Busca o usuário no banco através do login
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                _utilizadorService.GetUserAsync(credenciais);

                Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                usuario.PasswordHash = hash; //Se o usuário existir, executa a criptografia 
                usuario.PasswordSalt = salt; //guardando o hash e o salt nas propriedades do usuário 

                _context.TB_UTILIZADOR.Update(usuario);
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
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
                UtilizadorModel usuario = await _context.TB_UTILIZADOR //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.IdUtilizador == u.IdUtilizador);

                usuario.Email = u.Email;                

                var attach = _context.Attach(usuario);
                attach.Property(x => x.IdUtilizador).IsModified = false;
                attach.Property(x => x.Email).IsModified = true;                

                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
