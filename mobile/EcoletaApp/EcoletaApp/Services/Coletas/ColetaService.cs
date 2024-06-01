using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.Models;

namespace EcoletaApp.Services.Coletas
{
    public class ColetaService
    {
        private readonly Request _request;
        private const string apiURLBase = "http://SustenTechDS.somee.com/Ecoleta/api/Coleta";

        public ColetaService() 
        {
            _request = new Request();
        }
      
        public async Task<Coleta> PostColetaAsync(Coleta c)
        {
            string urlComplementar = "/";
            return await _request.PostSemTokenAsync(apiURLBase + urlComplementar, c);
         
        }

        public async Task<int> PostColetaIndIdAsync(Coleta c)
        {
            string urlComplementar = "/";
            Coleta result = await _request.PostSemTokenAsync(apiURLBase + urlComplementar, c);
            return result.IdColeta;
        }


        public async Task<ObservableCollection<Coleta>> GetColetaAllAsync()
        {
            string urlComplementar = string.Format("/");

            ObservableCollection<Models.Coleta> lista = await _request.GetSemTokenAsync<ObservableCollection<Models.Coleta>>(apiURLBase + urlComplementar);

            return lista;
        }

        public async Task<Coleta> GetColetaAsync(int Id)
        {
            string urlComplementar = string.Format("/{0}", Id);
            var coleta = await _request.GetSemTokenAsync<Models.Coleta>(apiURLBase + urlComplementar);

            return coleta;
        }


        public async Task<int> putColeta(Coleta c)
        {
            string urlComplementar = string.Format("/{0}", c.IdColeta);
            var result = await _request.PutSemTokenAsync(apiURLBase + urlComplementar, c);

            return result;

        }

        public async Task<int> DeleteColetaAsync(int c)
        {
            string urlComplementar = string.Format("/{0}", c);

            return await _request.DeleteSemTokenAsync(apiURLBase+urlComplementar);
        }

    }
}
