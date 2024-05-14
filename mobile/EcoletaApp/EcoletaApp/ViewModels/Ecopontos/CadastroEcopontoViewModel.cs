﻿using System;
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
        private int cep;
        private int latitude;
        private int longitude;

        public int IdEcoponto { get => idEcoponto; set {idEcoponto = value;OnPropertyChanged(nameof(IdEcoponto)); } }
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
        public int Latitude { get => latitude; set { latitude = value; OnPropertyChanged(nameof(Latitude)); } }
        public int Longitude { get => longitude; set { longitude = value; OnPropertyChanged(nameof(Longitude)); } }


        public async Task salvarEcoponto()
        {
            try 
            {
                Ecoponto model = new Ecoponto();
                {
                    Nome = this.nome;
                    CNPJ = this.cnpj;
                    RazaoSocial = this.razaoSocial;
                    Logradouro = this.logradouro;
                    Endereco = this.endereco;
                    Complemento = this.complemento;
                    Bairro = this.bairro;
                    Cidade = this.cidade;
                    UF = this.uf;
                    CEP = this.cep;
                    Latitude = this.latitude;
                    Longitude = this.longitude;
                    IdEcoponto = this.idEcoponto;
                };

                if(model.IdEcoponto == 0)
                    await eService.PostRegsistrarEcopontoAsync(model);

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