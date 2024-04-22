using EcoletaApp.Models;
using EcoletaApp.Services.Ecopontos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.ViewModels.Ecopontos
{
    public class ListagemEcopontoViewModel : BaseViewModel
    {
        private EcopontoService _service;

        public ObservableCollection<Ecoponto> Ecopontos { get; set; }

        public ListagemEcopontoViewModel()
        {
            _service = new EcopontoService();
            Ecopontos = new ObservableCollection<Ecoponto>();

            _ = ObterEcopontos();
        }


        public async Task ObterEcopontos()
        {
            try
            { 
                Ecopontos = await _service.GetEcopontosAsync();
                OnPropertyChanged(nameof(Ecopontos));
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage.DisplayAlert("OPS",
                    ex.Message + "Detalhes:" + ex.InnerException, "OK");
            }
        }
        }
}
