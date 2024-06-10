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
    [QueryProperty("EcopointSelecionadoId", "eId")]
    class CadastroEcopontoViewModel : BaseViewModel
    {
        private EcopontoService eService;
        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; }

        public CadastroEcopontoViewModel()
        {
            eService = new EcopontoService();

            SalvarCommand = new Command(async () => { await salvarEcoponto(); });
            CancelarCommand = new Command(async => CancelarCadstro());
        }


        #region Atributos

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
        private int cep;
        private double latitude;
        private double longitude;
        private string username;
        private string passwordString;
        private string email;
        private byte[] passwordHash;
        private byte[] passwordSalt;

     

    public int IdEcoponto { get => idEcoponto; set { idEcoponto = value;OnPropertyChanged(nameof(IdEcoponto));}
        }
        public string Nome { get => nome; set { nome = value; OnPropertyChanged(nameof(Nome)); } }
        public int CNPJ { get => cnpj; set { cnpj = value; OnPropertyChanged(nameof(CNPJ)); } }   
        public string RazaoSocial { get => razaoSocial; set { razaoSocial = value; OnPropertyChanged(nameof(RazaoSocial)); } }
        public string Logradouro { get => logradouro; set { logradouro = value; OnPropertyChanged(nameof(Logradouro)); } }
        public string Endereco { get => endereco; set { endereco = value; OnPropertyChanged(nameof(Endereco)); } }
        public string Complemento { get => complemento; set { complemento = value; OnPropertyChanged(nameof(Complemento)); }}
        public string Bairro { get => bairro; set { bairro = value; OnPropertyChanged(nameof(Bairro)); } }
        public string Cidade { get => cidade; set { cidade = value; OnPropertyChanged(nameof(Cidade)); } }
        public string UF { get => uf; set { uf = value; OnPropertyChanged(nameof(UF)); } }
        public int CEP { get => cep; set { cep = value; OnPropertyChanged(nameof(CEP)); } }
        public double Latitude { get => latitude; set { latitude = value; OnPropertyChanged(nameof(Latitude)); } }
        public double Longitude { get => longitude; set { longitude = value; OnPropertyChanged(nameof(Longitude)); } }     
        public string Username { get => username; set { username = value; OnPropertyChanged(nameof(username)); } }
        public string PasswordString { get => passwordString; set { passwordString = value; OnPropertyChanged(nameof(passwordString)); } }
        public string Email { get => email; set { email = value; OnPropertyChanged(nameof(email)); } }
        public byte[] PasswordHash { get => passwordHash; set { passwordHash = value; OnPropertyChanged(nameof(passwordHash)); } }
        public byte[] PasswordSalt { get => passwordSalt; set { passwordSalt = value; OnPropertyChanged(nameof(passwordSalt)); } }

        private string ecopontoSelecionadoId;
        public string EcopontoSelecionadoId { get => ecopontoSelecionadoId; set { if (value != null) { ecopontoSelecionadoId = Uri.UnescapeDataString(value); CarregarEcoponto(); } } }

        #endregion


        public async Task salvarEcoponto()
        {
            try 
            {

                Ecoponto model = new Ecoponto
                {
                    Nome = this.Nome,
                    CNPJ = this.CNPJ,
                    RazaoSocial = this.RazaoSocial,
                    Logradouro = this.Logradouro,
                    Endereco = this.Endereco,
                    Complemento = this.Complemento,
                    Bairro = this.Bairro,
                    Cidade = this.Cidade,
                    UF = this.UF,
                    CEP = this.CEP,
                    Latitude = this.Latitude,
                    Longitude = this.Longitude,
                    IdEcoponto = this.IdEcoponto,
                    Username = this.Username,
                    PasswordString = this.PasswordString,
                    Email = this.Email,
                    PasswordHash = this.PasswordHash,
                     PasswordSalt = this.PasswordSalt
                     // isso aqui tem que revisar depois no método put
                };


                if (model.IdEcoponto == 0)
                    await eService.PostEcopontoAsync(model);
                else
                    await eService.PutEcopontoAsync(model);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "OK");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex) 
            {
                await Shell.Current.GoToAsync("..");            

                await Application.Current.MainPage
                    .DisplayAlert("OPS", ex.Message + "Detalhes" + ex.InnerException, "Ok");                

            }
        }

        public async void CarregarEcoponto()
        { 
            try
            {
                Ecoponto e = await eService.GetEcopontoAsync(int.Parse(ecopontoSelecionadoId));

                this.Nome = e.Nome;
                this.CNPJ = e.CNPJ;
                this.RazaoSocial = e.RazaoSocial;
                this.Logradouro = e.Logradouro;
                this.Endereco = e.Endereco;
                this.Complemento = e.Complemento;
                this.Bairro = e.Bairro;
                this.Cidade = e.Cidade;
                this.UF = e.UF;
                this.CEP = e.CEP;
                this.Latitude = e.Latitude;
                this.Longitude = e.Longitude;
                this.IdEcoponto = e.IdEcoponto;
                this.Username = e.Username;
                this.PasswordString = e.PasswordString;
                this.Email = e.Email;
                this.passwordSalt = e.PasswordSalt;
                this.PasswordHash = e.PasswordHash;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("OPS", ex.Message + "Detalhes" + ex.InnerException, "Ok");
            }
        }

        private async void CancelarCadstro()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
