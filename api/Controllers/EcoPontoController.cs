using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Models.Enuns;
using System.Collections.Generic;
using api.Data;

namespace api.Controllers
{
    public class EcoPontoController : ControllerBase
    {
        private readonly List<EcopontoModel> ecopontos;
        private readonly DataContext _context;

        public EcopontoController(DataContext context)
        {
            ecopontos = new List<EcopontoModel>();
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EcopontoModel>> Get()
        {
            return Ok(ecopontos);
        }
    }
}