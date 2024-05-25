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
    public class RegistrarColetaViewModel : BaseViewModel
    {
        private ColetaService cService;

        public ICommand RegistarCommand { get; }
        public ICommand CancelarCommand { get; }

        public RegistrarColetaViewModel()
        {
            cService = new ColetaService();

            RegistarCommand = new Command(async () => { await RegistrarColetaAsync(); });
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
        private string sitituacaoColeta;

        public int IdColeta { get => idColeta; set { idColeta = value; OnPropertyChanged(nameof(idColeta)); } }
        public int IdEcoponto { get => idEcoponto; set { idEcoponto = value; OnPropertyChanged(nameof(idEcoponto)); } }
        public int IdUtilizador { get => idUtilizador; set { idUtilizador = value; OnPropertyChanged(nameof(idUtilizador)); } }
        public int CodigoUtilizador { get => codigoUtilizador; set { codigoUtilizador = value; OnPropertyChanged(nameof(codigoUtilizador)); } }
        public int CodigoEcoponto { get => codigoEcoponto; set { codigoEcoponto = value; OnPropertyChanged(nameof(codigoEcoponto)); } }
        public DateTime DataColeta { get => dataColeta; set { dataColeta = value; OnPropertyChanged(nameof(dataColeta)); } }
        public float TotalEcopoints { get => totalEcopoints; set { totalEcopoints = value; OnPropertyChanged(nameof(totalEcopoints)); } }
        public double Peso { get => peso; set { peso = value; OnPropertyChanged(nameof(peso)); } }
        public string SituacaoColeta { get => sitituacaoColeta; set{ sitituacaoColeta = value; OnPropertyChanged(nameof(sitituacaoColeta)); } }

        #endregion

        public async Task RegistrarColetaAsync()
        {
            try
            { 
                Coleta coleta = new Coleta();
                {
                    IdColeta = this.idColeta;
                    IdEcoponto = this.idEcoponto;
                    IdUtilizador = this.idUtilizador;
                    CodigoEcoponto = this.codigoEcoponto;
                    CodigoUtilizador = this.codigoUtilizador;
                    DataColeta = this.dataColeta;
                    TotalEcopoints = this.totalEcopoints;
                    Peso = this.peso;
                    SituacaoColeta = "Aprovado";
                };

                if (coleta.IdColeta == 0)          
                    await cService.PostColetaAsync(coleta);  
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

        public async Task CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
