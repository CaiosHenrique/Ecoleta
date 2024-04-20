using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;

namespace api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ColetaController : ControllerBase
    {
        
    private readonly DataContext _context;
    private readonly List<ColetaModel> coletas;

        public ColetaController(DataContext context)
        {
            coletas = new List<ColetaModel>();
            _context = context;
        }

        [HttpGet]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<ColetaModel>> GetAll()
        {
            try
            {
                var coletas = _context.TB_COLETA.ToList();
                return StatusCode(200, coletas);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }
       
        [HttpGet("{IdColeta}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ColetaModel> GetId(int IdColeta)
        {
            try
            {
                var coleta = _context.TB_COLETA.Find(IdColeta);

                if (coleta == null)
                {
                    return StatusCode(404);

                }
                    return StatusCode(200, coleta);

            }

            catch (System.Exception)
            {
                    return StatusCode(500);

            }

        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ColetaModel> PostColeta([FromBody] ColetaModel coleta)
        {
            try
            {
                _context.TB_COLETA.Add(coleta);
                _context.SaveChanges();
                return StatusCode(201, coleta);

            }

            catch (System.Exception)
            {
                return StatusCode(500);

            }

        }

        [HttpPut("{IdColeta}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<ColetaModel> PutColeta(int IdColeta, [FromBody] ColetaModel coleta)
        {
            try
            {
                var coletaAtual = _context.TB_COLETA.Find(IdColeta);

                if (coletaAtual == null)
                {
                    return StatusCode(400);
                }

                coletaAtual.IdColeta = coleta.IdColeta;
                coletaAtual.IdEcoponto = coleta.IdEcoponto;
                coletaAtual.IdUtilizador = coleta.IdUtilizador;
                coletaAtual.CodigoEcoponto = coleta.CodigoEcoponto;
                coletaAtual.CodigoUtilizador = coleta.CodigoUtilizador;
                coletaAtual.DataColeta = coleta.DataColeta;
                coletaAtual.TotalEcopoints = coleta.TotalEcopoints;
                coletaAtual.Peso = coleta.Peso;
                coletaAtual.SituacaoColeta = coleta.SituacaoColeta;

                _context.SaveChanges();
                return StatusCode(200, coletaAtual);

            }

            catch (System.Exception)
            {
                return StatusCode(400);

            }

        }

        [HttpDelete("{IdColeta}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ColetaModel> Delete(int IdColeta)
        {
            try
            {
                var coleta = _context.TB_COLETA.Find(IdColeta);

                if (coleta == null)
                {
                    return StatusCode(404);

                }

                _context.TB_COLETA.Remove(coleta);
                _context.SaveChanges();
                return StatusCode(200, coleta);

            }
            catch (System.Exception)
            {
                return StatusCode(500);

            }
        }
    }
}