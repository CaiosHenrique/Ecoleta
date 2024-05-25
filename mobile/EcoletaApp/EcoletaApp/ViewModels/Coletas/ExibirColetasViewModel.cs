using EcoletaApp.Models;
using EcoletaApp.Services.Coletas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EcoletaApp.ViewModels.Coletas
{
    class ExibirColetasViewModel : BaseViewModel
    {
        private ColetaService cService;

        public ObservableCollection<Coleta> Coletas { get; set; }
        public ICommand RegistrarCommand { get; }

        public ExibirColetasViewModel()
        {
            cService = new ColetaService();
            Coletas = new ObservableCollection<Coleta>();

            _ = ObterColetas();

            RegistrarCommand = new Command(async () => { await ExibirTelaRegistro(); }); 
        }

        public async Task ObterColetas()
        {
            try
            {
                Coletas = await cService.GetColetaAllAsync();
                OnPropertyChanged(nameof(Coletas));
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
                await Shell.Current.GoToAsync("cadColetaView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }


    }
}
