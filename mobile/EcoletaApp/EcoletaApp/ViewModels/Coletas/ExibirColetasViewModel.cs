using EcoletaApp.Models;
using EcoletaApp.Services.Coletas;
using EcoletaApp.ViewModels.Ecopontos;
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
        public ICommand RemoverColetaCommand { get; }



        public ExibirColetasViewModel()
        {
            cService = new ColetaService();
            Coletas = new ObservableCollection<Coleta>();

            _ = ObterColetas();

            RegistrarCommand = new Command(async () => { await ExibirTelaRegistro(); });
            RemoverColetaCommand = new Command<Coleta>(async (Coleta c) => { await RemoverColeta(c); });
        }

        private Coleta coletaSelecionada;
        public Coleta ColetaSelecionada
        {
            get { return coletaSelecionada; }
            set
            {
                if (value != null)
                {
                    coletaSelecionada = value;   

                    Shell.Current.GoToAsync($"cadColetaView?cId={coletaSelecionada.IdColeta}");
                }
            }
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

        public async Task RemoverColeta(Coleta c)
        {
            try
            {
                if (await Application.Current.MainPage.DisplayAlert("Confirmação", $"Confirmação a remoção da coleta com Id: {c.IdColeta}?", "Sim", "Não"));
                {
                    await cService.DeleteColetaAsync(c.IdColeta);

                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Coleta Removida Com sucesso!", "OK");

                    _ = ObterColetas();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + "Detalhes :" + ex.InnerException, "Ok");
            }
        }

  

    }
}
