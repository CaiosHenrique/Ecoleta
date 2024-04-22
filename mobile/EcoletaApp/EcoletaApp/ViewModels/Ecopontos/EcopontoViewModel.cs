using EcoletaApp.Services.Ecopontos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.Services;
using EcoletaApp.Models;
using System.Windows.Input;
using EcoletaApp.Views.Ecoponto;

namespace EcoletaApp.ViewModels.Ecopontos
{
    public class EcopontoViewModel: BaseViewModel
    {
        public EcopontoViewModel()
        {
            eService = new EcopontoService();
            InicializarCommands();
        }

        private EcopontoService eService;

        public ICommand RegistrarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarEcoponto());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
        }

        private int idEcoponto = 0;
        private string nome = string.Empty;
        private int cnpj = 0;
        private string razaoSocial = string.Empty;
        private string logradouro = string.Empty;
        private string endereco = string.Empty;
        private string complemento = string.Empty;
        private string bairro = string.Empty;
        private string cidade = string.Empty;
        private string uf = string.Empty;
        private int cep = 0;
        private int latitude = 0;
        private int longitude = 0;

        public async Task RegistrarEcoponto()
        {
            try
            {
                Ecoponto e = new Ecoponto();
                e.Nome = nome;
                e.CNPJ = cnpj;
                e.RazaoSocial = razaoSocial;
                e.Logradouro = logradouro;
                e.Endereco = endereco;
                e.Complemento = complemento;
                e.Bairro = bairro;
                e.Cidade = cidade;
                e.UF = uf;
                e.CEP = cep;
                e.Latitude = latitude;
                e.Longitude = longitude;

                Ecoponto eRegistrado = await eService.PostRegsistrarEcopontoAsync(e);

                if (eRegistrado.IdEcoponto != 0)
                {
                    string mensagem = $"Usário Id {eRegistrado.IdEcoponto} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "OK");

                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação",
                        ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }


        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes:" + ex.InnerException, "OK");
            }
        }
    }
}
