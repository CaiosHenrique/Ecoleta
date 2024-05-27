using EcoletaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.ViewModels;
using System.Collections.ObjectModel;

namespace EcoletaApp.Services.Ecopontos
{
    public class EcopontoService : Request
    {
        private readonly Request _request;
        private const string apiURLBase = "http://SustenTechDS.somee.com/Ecoleta/api/Ecoponto";

        public EcopontoService()
        { 
            _request = new Request();
        }

       

        public async Task<int>  PostRegsistrarEcopontoAsync(Ecoponto e)
        {
            string urlComplementar = "/";
           Ecoponto result = await _request.PostSemTokenAsync<Models.Ecoponto>(apiURLBase + urlComplementar, e);

            return result.IdEcoponto;
        }


        // isso tem que Revisar Depois pois o banco Ainda não está corrigido
        public async Task<Ecoponto> PostEcopontoAsync(Ecoponto e)
        {
            string urlComplementar = "/Registrar";
                return await _request.PostSemTokenAsync(apiURLBase + urlComplementar, e);            
        }

        public async Task<ObservableCollection<Ecoponto>> GetEcopontosAsync()
        {
            ObservableCollection<Models.Ecoponto> listaEcopontos = await _request
                .GetSemTokenAsync<ObservableCollection<Models.Ecoponto>>(apiURLBase);

            return listaEcopontos;
        }

        public async Task<Ecoponto> GetEcopontoAsync(int Id)
        {
            string urlComplementar = string.Format("/{0}", Id);
            var ecoponto = await _request.GetSemTokenAsync<Models.Ecoponto>(apiURLBase + urlComplementar);
            return ecoponto;
        }

        public async Task<int> PutEcopontoAsync(Ecoponto e)
        {
            string urlComplementar = string.Format("/{0}", e.IdEcoponto);
            var result = await _request.PutSemTokenAsync(apiURLBase +  urlComplementar, e);
            return result;
        }

        public async Task<int> DeleteEcopontoAsync(int e)
        {
            string urlComplementar = string.Format("/{0}", e);
            var result = await _request.DeleteSemTokenAsync( apiURLBase + urlComplementar);
            return result;
        }

        

      
    }
}
