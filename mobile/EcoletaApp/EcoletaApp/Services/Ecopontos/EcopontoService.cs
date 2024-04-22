using EcoletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.ViewModels;

namespace EcoletaApp.Services.Ecopontos
{
    public class EcopontoService
    {
        private readonly Request _request;
        private const string apiURLBase = "http://www.sustentechds.somee.com/EcoPonto";

        public EcopontoService()
        { 
            _request = new Request();
        }

       

        public async Task<Ecoponto>  PostRegsistrarEcopontoAsync(Ecoponto e)
        {
            string urlComplementar = "/PostEcoponto";
            e.IdEcoponto = await _request.PostReturnIntAsync(apiURLBase + urlComplementar, e);
            return e;
        }

       




    }
}
