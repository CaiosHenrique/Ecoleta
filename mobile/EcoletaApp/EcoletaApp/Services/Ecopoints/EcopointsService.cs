using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.Models;

namespace EcoletaApp.Services.EcopointsService
{
    public class EcopointsService
    {
        private readonly Request _request;
        private const string apiURLBase = "http://SustenTechDS.somee.com/Ecoleta/api/EcoPoints";

        public EcopointsService()
        {
            _request = new Request();
        }

        public async Task<int> PostRegistrarEcopointsAsync(Ecopoints e)
        {
            string urlComplementar = "/";
            return await _request.PostReturnIntAsync(apiURLBase + urlComplementar, e);
        }

        public async Task<ObservableCollection<Ecopoints>> GetEcopointsAllAsync()
        {
             ObservableCollection< Models.Ecopoints> lista = await _request.GetSemTokenAsync<ObservableCollection<Models.Ecopoints>>(apiURLBase);
              
            return lista;
        }

        public async Task<Ecopoints> GetEcopointsAsync(int id)
        {
            string urlComplementar = string.Format("/{0}", id);
            var result = await _request.GetSemTokenAsync<Models.Ecopoints>(apiURLBase + urlComplementar);

            return result;
        }

        public async Task<int> PutEcopointsAsync(Ecopoints e)
        {
            string urlComplementar = string.Format("/{0}", e.IdMaterial);
            var result = await _request.PutSemTokenAsync(apiURLBase+urlComplementar, e);

            return result;
        }

        public async Task<int> DeleteEcopointAsync(int e)
        {
            string urlComplementar = string.Format("/{0}", e);
            return await _request.DeleteSemTokenAsync(apiURLBase+urlComplementar);
        }


    }
}
