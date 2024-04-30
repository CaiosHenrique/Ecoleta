using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EcoletaApp.Models;
using EcoletaApp.Services;
using EcoletaApp.Services.Ecopontos;

namespace EcoletaApp.ViewModels.Ecopontos
{
    class CadastroEcopontoViewModel : BaseViewModel
    {
        private EcopontoService eService;
        public ICommand SalvarCommand { get; }

        public CadastroEcopontoViewModel()
        {
            eService = new EcopontoService();

            SalvarCommand = new Command(async () => { await salvarEcoponto(); });
        }


        private int idEcoponto;
        private string nome;
        private int cnpj;
        private string razaoSocial;
        private string logradouro;
        private string endereco;
        private string complemento;
        private string bairro;
        private string cidade;
        private string uf;
        private string cep;
        private int latitude;
        private int longitude;

        public int IdEcoponto { get => idEcoponto; set {idEcoponto = value;OnPropertyChanged(); } }
        public string Nome { get => nome; set { nome = value; OnPropertyChanged(); } }
        public int Cnpj { get => cnpj; set { cnpj = value; OnPropertyChanged(); } }   
        public string RazaoSocial { get => razaoSocial; set { razaoSocial = value; OnPropertyChanged(); } }
        public string Logradouro { get => logradouro; set { logradouro = value; OnPropertyChanged(); } }
        public string Endereco { get => endereco; set { endereco = value; OnPropertyChanged(); } }
        public string Complemento { get => complemento; set { complemento = value; OnPropertyChanged(); }}
        public string Bairro { get => bairro; set { bairro = value; OnPropertyChanged(); } }
        public string Cidade { get => cidade; set { cidade = value; OnPropertyChanged(); } }
        public string Uf { get => uf; set { uf = value; OnPropertyChanged(); } }
        public string Cep { get => cep; set { cep = value; OnPropertyChanged(); } }
        public int Latitude { get => latitude; set { latitude = value; OnPropertyChanged(); } }
        public int Longitude { get => longitude; set { longitude = value; OnPropertyChanged(); } }


        public async Task salvarEcoponto()
        {
            try 
            {
                Ecoponto model = new Ecoponto();
                {
                    Nome = this.nome;
                    Cnpj = this.cnpj;
                    RazaoSocial = this.razaoSocial;
                    Logradouro = this.logradouro;
                    Endereco = this.endereco;
                    Complemento = this.complemento;
                    Bairro = this.bairro;
                    Cidade = this.cidade;
                    Uf = this.uf;
                    Cep = this.cep;
                    Latitude = this.latitude;
                    Longitude = this.longitude;
                };

                if(model.IdEcoponto == 0)
                    await eService.PostEcopontoAsync(model);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "OK");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                    .DisplayAlert("OPS", ex.Message + "Detalhes" + ex.InnerException, "Ok");
            }
        }

    }
}
