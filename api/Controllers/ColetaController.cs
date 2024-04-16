using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;

namespace api.Controllers
{

    public class ColetaController : ControllerBase
    {
        
    private readonly DataContext _context;
    private readonly List<ColetaModel> coletas;

        public ColetaController(DataContext context)
        {
            coletas = new List<ColetaModel>();
            _context = context;
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
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ColetaModel> Post([FromBody] ColetaModel coleta)
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