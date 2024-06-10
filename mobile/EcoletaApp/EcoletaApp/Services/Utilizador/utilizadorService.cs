using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<int> PutAtualizarLocalizacaoAsync(Utilizador u)
        {
            string urlComplementar = "/AtualizarLocalizacao";
            var result = await _request.PutSemTokenAsync(ApiUrlBase + urlComplementar, u);
            return result;
        }
        //using System.Collections.ObjectModel
        public async Task<ObservableCollection<Utilizador>> GetUsuariosAsync()
        {
            string urlComplementar = "/GetAll";
            ObservableCollection<Models.Utilizador> listaUsuarios = await
            _request.GetSemTokenAsync<ObservableCollection<Models.Utilizador>>(ApiUrlBase + urlComplementar);
            return listaUsuarios;
        }

        public async Task<Utilizador> GetutilizadorAsync(int uId)
        {
            string urlComplementar = string.Format("{0}", "uId");
            Utilizador u = await _request.GetSemTokenAsync<Models.Utilizador>(ApiUrlBase + urlComplementar);

            return u;
        }


    }
}
