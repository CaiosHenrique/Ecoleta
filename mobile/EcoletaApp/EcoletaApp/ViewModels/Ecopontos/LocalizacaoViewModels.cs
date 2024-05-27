using EcoletaApp.Models;
using EcoletaApp.Services.Ecopontos;
using EcoletaApp.Services.UtilizadorService;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Map = Microsoft.Maui.Controls.Maps.Map;


namespace EcoletaApp.ViewModels.Ecopontos
{
    public class LocalizacaoViewModels : BaseViewModel
    {

        private utilizadorService uService;
        private EcopontoService eService;
        private Map meuMapa;

        public LocalizacaoViewModels( )
        { 
            uService = new utilizadorService();
            eService = new EcopontoService();
        }


        public Map MeuMapa { get => meuMapa; set { if (value != null) { meuMapa = value; OnPropertyChanged(nameof(meuMapa)); }  } }

        

        public async void InicializarMapa()
        {
            try
            { 
                Location location = new Location( -32.5200241d, -46.596498d);
                Pin pinEtec = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Etec Horácio",
                    Address = "Rua alcântara, 113, Vila Guilherme",
                    Location = location
                };

                Map map = new Map();
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(5));
                map.Pins.Add(pinEtec);
                map.MoveToRegion(mapSpan);

                MeuMapa = map;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Erro", ex.Message, "OK");
            }           
        }

        public async void ExibirUsuariosnoMapa()
        {
            try
            { 
                ObservableCollection<Utilizador> ocUtilizador = await uService.GetUsuariosAsync();
                List<Utilizador> listUtilizador = new List<Utilizador>(ocUtilizador);
                Map map = new Map();

                foreach (Utilizador u in listUtilizador)
                {
                    if (u.Latitude != null && u.Longitude != null)
                    { 
                        double latitude = (double)u.Latitude;
                        double longitude = (double)u.Longitude;
                        Location location = new Location(latitude, longitude);

                        Pin pinEtec = new Pin()
                        {
                            Type = PinType.Place,
                            Label = u.Username,
                            Address = $"E-mail: {u.Email}",
                            Location = location
                        };
                        map.Pins.Add(pinEtec);
                    }
                    MeuMapa = map;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
