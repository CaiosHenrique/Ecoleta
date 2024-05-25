using EcoletaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Services.Brindes
{
    public class BrindesServices : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://SustenTechDS.somee.com/Ecoleta/api/Brinde";

        public BrindesServices()
        {
            _request = new Request();
        }

        public async Task<int> PostBrindeAsync(Brinde b)
        {
            string urlComplementar = "/";
            return await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, b);
        }

        public async Task<ObservableCollection<Brinde>> GetAllBrindeAsync()
        {
            ObservableCollection<Models.Brinde> lista = await _request.GetSemTokenAsync<ObservableCollection<Models.Brinde>>(apiUrlBase);

            return lista;
        }

        public async Task<Brinde> GetBrindeIdAsync(int id)
        {
            string urlComplementar = string.Format("/{0}", id);
            var brinde = await _request.GetSemTokenAsync<Models.Brinde>(apiUrlBase + urlComplementar);
           
            return brinde;
        }

        public async Task<int> PutBrindeAsync(Brinde b)
        {
            string urlComplementar = string.Format("/{0}", b.IdBrinde);
            var result = await _request.PutSemTokenAsync(apiUrlBase + urlComplementar, b);

            return result;  
        }

        public async Task<int> DeleteBrindeAsync(int id)
        {
            string urlComplementar = string.Format("/{0}", id);
            var retult = await _request.DeleteSemTokenAsync(apiUrlBase + urlComplementar);
            
            return retult;

        }


    }
}
