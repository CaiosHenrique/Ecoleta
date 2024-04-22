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
    public class EcopontoService
    {
        private readonly Request _request;
        private const string apiURLBase = "http://SustenTechDS.somee.com/Ecoleta/api/Ecoponto/";

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

        public async Task<Ecoponto> PostEcopontoAsync(Ecoponto e)
        {
                return await _request.PostSemTokenAsync(apiURLBase, e);            
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
            var result = await _request.PutSemTokenAsync(apiURLBase, e);
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
