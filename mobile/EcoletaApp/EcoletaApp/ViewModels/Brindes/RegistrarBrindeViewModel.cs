using EcoletaApp.Models;
using EcoletaApp.Services.Brindes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcoletaApp.ViewModels.Brindes
{
    [QueryProperty("PersonagemSelecionadoId","bId")]
    public class RegistrarBrindeViewModel : BaseViewModel
    {
        private BrindesServices bService;

        public RegistrarBrindeViewModel()
        { 
            bService = new BrindesServices();

            SalvarCommand = new Command(async ()=> { await RegistrarBrinde(); });
            CancelarCommand = new Command(async () => { await CancelarCadastro(); });
        }

        public ICommand CancelarCommand { get; }
        public ICommand SalvarCommand { get; }


        #region Atributos

        private int idBrinde;
        private string descricaoBrinde;
        private string nomebrinde;
        private char cadastro; // Char(1);
        private DateTime validade;
        private int quantidade;
        private int saldo;
        private int valorEcopoints;

        public int IdBrinde { get => idBrinde; set { idBrinde = value; OnPropertyChanged(nameof(idBrinde)); } }
        public string DescricaoBrinde { get => descricaoBrinde; set { descricaoBrinde = value; OnPropertyChanged(nameof(descricaoBrinde)); } }
        public string Nomebrinde { get => nomebrinde; set { nomebrinde = value; OnPropertyChanged(nameof(nomebrinde)); } }
        public char Cadastro { get => cadastro; set{  cadastro = value; OnPropertyChanged(nameof(cadastro)); } }
        public DateTime Validade { get => validade; set { validade = value; OnPropertyChanged(nameof(validade)); } }
        public int Quantidade { get => quantidade; set {quantidade = value; OnPropertyChanged(nameof(quantidade)); } }
        public int Saldo { get => saldo;  set {saldo = value; OnPropertyChanged(nameof(saldo)); } }
        public int ValorEcopoints { get => valorEcopoints; set { valorEcopoints = value; OnPropertyChanged(nameof(valorEcopoints)); } }



        private string brindeSelecionadoId;
        public string BrindeSelecionadoId { set { if (value != null) { brindeSelecionadoId = Uri.UnescapeDataString(value);  CarregarBrinde(); } } }


        #endregion

        public async Task RegistrarBrinde()
        {
            try
            {
                Brinde brinde = new Brinde();
                {
                    IdBrinde = this.IdBrinde;
                    DescricaoBrinde = this.DescricaoBrinde;
                    Nomebrinde = this.Nomebrinde;
                    Cadastro = this.Cadastro;
                    Validade = this.Validade;
                    Quantidade = this.Quantidade;
                    Saldo = this.Saldo;
                    ValorEcopoints = this.ValorEcopoints;
                }

                if (brinde.IdBrinde == 0)
                {
                    await bService.PostBrindeAsync(brinde);
                }
                else
                { 
                    await bService.PutBrindeAsync(brinde);
                }

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Brinde Salvo com Sucesso", "Ok");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }

        public async Task CarregarBrinde()
        {
            try
            {
                Brinde b = await bService.GetBrindeIdAsync(int.Parse(brindeSelecionadoId));
                
          
                this.Nomebrinde = b.NomeBrinde;
                this.descricaoBrinde = b.DescricaoBrinde;
                this.Cadastro = b.Cadastro;
                this.Validade = this.Validade;
                this.Saldo = b.Saldo;
                this.Quantidade = b.Quantidade;
                this.valorEcopoints = b.ValorEcopoints;

                

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }

        public async Task CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
