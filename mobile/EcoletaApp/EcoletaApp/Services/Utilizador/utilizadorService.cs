using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.Models;

namespace EcoletaApp.Services.UtilizadorService
{
    public  class utilizadorService : Request
    {
        private readonly Request _request;
        private const string ApiUrlBase = "http://SustenTechDS.somee.com/Ecoleta/api/Ecoponto";

        public utilizadorService()
        { 
            _request = new Request();
        }

        public async Task<Utilizador> PostRegistrarUtilizadorAsync(Utilizador u)
        {
            string urlComplementar = "/Registrar";
            u.IdUtilizador = await _request.PostReturnIntAsync(ApiUrlBase + urlComplementar, u);

            return u;
        }

        public async Task<Utilizador> PostAutenticarUtilizadorAsync(Utilizador u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostSemTokenAsync(ApiUrlBase + urlComplementar, u);


            return u;
        }



    }
}
