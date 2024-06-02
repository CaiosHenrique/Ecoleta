using EcoletaApp.Services.Coletas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.Models;
using System.Windows.Input;

namespace EcoletaApp.ViewModels.Coletas
{
    [QueryProperty("ColetaSelencionadaId", "cId")]
    public class RegistrarColetaViewModel : BaseViewModel
    {
        private ColetaService cService;

        public ICommand RegistrarCommand { get; }
        public ICommand CancelarCommand { get; }

        public RegistrarColetaViewModel()
        {
            cService = new ColetaService();

            RegistrarCommand = new Command(async () => { await RegistrarColetaAsync(); });
            CancelarCommand = new Command(async () => { await CancelarCadastro(); });
        }


        #region Atributos

        private int idColeta;
        private int idEcoponto;
        private int idUtilizador;
        private int codigoUtilizador;
        private int codigoEcoponto;
        private DateTime dataColeta;
        private float totalEcopoints;
        private Double peso;
        private string situacaoColeta;

        public int IdColeta { get => idColeta; set { idColeta = value; OnPropertyChanged(nameof(IdColeta)); } }
        public int IdEcoponto { get => idEcoponto; set { idEcoponto = value; OnPropertyChanged(nameof(IdEcoponto)); } }
        public int IdUtilizador { get => idUtilizador; set { idUtilizador = value; OnPropertyChanged(nameof(IdUtilizador)); } }
        public int CodigoUtilizador { get => codigoUtilizador; set { codigoUtilizador = value; OnPropertyChanged(nameof(CodigoUtilizador)); } }
        public int CodigoEcoponto { get => codigoEcoponto; set { codigoEcoponto = value; OnPropertyChanged(nameof(CodigoEcoponto)); } }
        public DateTime DataColeta { get => dataColeta; set { dataColeta = value; OnPropertyChanged(nameof(DataColeta)); } }
        public float TotalEcopoints { get => totalEcopoints; set { totalEcopoints = value; OnPropertyChanged(nameof(TotalEcopoints)); } }
        public double Peso { get => peso; set { peso = value; OnPropertyChanged(nameof(Peso)); } }
        public string SituacaoColeta { get => situacaoColeta; set{ situacaoColeta = value; OnPropertyChanged(nameof(SituacaoColeta)); } }


        private string coletaSelecionadaId;

        public string ColetaSelencionadaId { set { if (value != null) { coletaSelecionadaId = Uri.UnescapeDataString(value); CarregarColetaAsync(); } } }

        #endregion

        public async Task RegistrarColetaAsync()
        {
            try
            { 
                Coleta coleta = new Coleta();
                {
                    IdColeta = this.IdColeta;
                    IdEcoponto = this.IdEcoponto;
                    IdUtilizador = this.IdUtilizador;
                    CodigoEcoponto = this.IdEcoponto;
                    CodigoUtilizador = this.IdUtilizador;
                    DataColeta = DateTime.Now;
                    TotalEcopoints = this.TotalEcopoints;
                    Peso = this.Peso;
                    SituacaoColeta = "S";
                };
                

                if (coleta.IdColeta == 0)          
                    await cService.PostColetaIndIdAsync(coleta);  
                else
                    await cService.putColeta(coleta);

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados Salvos Com Sucesso!", "OK");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }

        public async void CarregarColetaAsync()
        {
            try
            {
                Coleta c = await cService.GetColetaAsync(int.Parse(coletaSelecionadaId));

                this.IdColeta = c.IdColeta;
                this.IdEcoponto = c.IdEcoponto;
                this.IdUtilizador = c.IdUtilizador;
                this.CodigoEcoponto = c.CodigoEcoponto;
                this.CodigoUtilizador = c.CodigoUtilizador;
                this.DataColeta = c.DataColeta;
                this.TotalEcopoints = c.TotalEcopoints;
                this.Peso = c.Peso;
                this.SituacaoColeta = c.SituacaoColeta;


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
