using EcoletaApp.Models;
using EcoletaApp.Services.EcopointsService;
using EcoletaApp.Services.UtilizadorService;
using EcoletaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecoleta.ViewModels.Ecopoint.ListagemEcopointsViewModel
{
    public class ListagemEcopointsViewModel : BaseViewModel
    {
        private EcopointsService eService;
        public ObservableCollection<Ecopoints> ecopoints { get; set; }


        public ListagemEcopointsViewModel()
        {
            eService = new EcopointsService();
            ecopoints = new ObservableCollection<Ecopoints>();

            _ = ObterEcopoints();
            CadEcopints = new Command(async () => await ExibirCadastro());
            RemoverCommand = new Command<Ecopoints>(async (Ecopoints e) => await RemoverEcopoints(e));
        }

        public ICommand CadEcopints { get; }
        public ICommand RemoverCommand{get;} 

        private Ecopoints ecopointSelecionado;
        public Ecopoints EcopointSelecionado { get{ return ecopointSelecionado; } set{ if (value != null) { ecopointSelecionado = value; Shell.Current.GoToAsync($"CadEcopointsView?eId={ecopointSelecionado.IdMaterial}"); } } }


        public async Task ObterEcopoints()
        {
            try
            {
                ecopoints = await eService.GetEcopointsAllAsync();
                OnPropertyChanged(nameof(ecopoints));
                            
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }

        public async Task ExibirCadastro()
        {
            try 
            {
                await Shell.Current.GoToAsync("cadEcopointsvew");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }

        public async Task RemoverEcopoints(Ecopoints e)
        {
            try
            {  if (await Application.Current.MainPage.DisplayAlert("Confirmação", $"Confirma a remoção de Ecopoints?", "Sim", "Não"))
                {
                    await eService.DeleteEcopointAsync(e.IdMaterial);

                    await Application.Current.MainPage.DisplayAlert("Mensagem", "Ecoponto Removido com Sucesso!", "OK");

                    _ = ObterEcopoints();

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }

        }
        

    }
}
