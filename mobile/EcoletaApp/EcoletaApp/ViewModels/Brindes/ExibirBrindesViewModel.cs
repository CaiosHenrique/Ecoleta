using EcoletaApp.Services.Brindes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoletaApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EcoletaApp.ViewModels.Brindes
{
    public class ExibirBrindesViewModel : BaseViewModel
    {
        private BrindesServices bService;
        private Brinde brindeSelecionado;
        public ExibirBrindesViewModel()
        {
            bService = new BrindesServices();
            Brindes = new ObservableCollection<Brinde>();

            _ = ObterBrindes();

            RegistrarCommand = new Command(async () => { await ExibirTelaRegistro(); });
        }

        public ObservableCollection<Brinde> Brindes {  get; set; }
        public ICommand RegistrarCommand { get; }
        public Brinde BrindeSelecionado 
        { 
            get {  return brindeSelecionado; } 
            set { if (value != null) brindeSelecionado = value; Shell.Current.GoToAsync($"cadBrindeView?bId={brindeSelecionado.IdBrinde}"); } 
        }

      

  

        public async Task ObterBrindes()
        {
            try
            { 
                Brindes = await bService.GetAllBrindeAsync();
                OnPropertyChanged(nameof(Brindes));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }

        public async Task ExibirTelaRegistro()
        {
            try
            {
                await Shell.Current.GoToAsync("cadBrindeView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }

    }
}
