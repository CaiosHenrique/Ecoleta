using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;
using Microsoft.EntityFrameworkCore;
using api.Utils;

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

        
        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<UtilizadorModel> Get(int id)
        {
            try
            {
                var utilizador = utilizadores.Find(u => u.IdUtilizador == id);

                if (utilizador == null)
                {
                return StatusCode(404);

                }

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }
                return StatusCode(200, utilizadores);

        }

        
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

        
        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult Delete(int id)
        {
            try
            {
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


        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.TB_UTILIZADOR.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(UtilizadorModel utilizador)
        {
            try
            {
                if (await UsuarioExistente(utilizador.Username))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(utilizador.PasswordString, out byte[] hash, out byte[] salt);
                utilizador.PasswordString = string.Empty;
                utilizador.PasswordHash = hash;
                utilizador.PasswordSalt = salt;
                await _context.TB_UTILIZADOR.AddAsync(utilizador);
                await _context.SaveChangesAsync();

                return Ok(utilizador.IdUtilizador);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(UtilizadorModel credenciais)
        {
            try
            {
                UtilizadorModel? usuario = await _context.TB_UTILIZADOR
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                     usuario.DataAcesso = System.DateTime.Now;
                    _context.TB_UTILIZADOR.Update(usuario);
                    await _context.SaveChangesAsync(); //Confirma a alteração no banco

                    return Ok(usuario);
                }
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

                if (usuario == null) //Se não achar nenhum usuário pelo login, retorna mensagem.
                    throw new System.Exception("Usuário não encontrado.");

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
