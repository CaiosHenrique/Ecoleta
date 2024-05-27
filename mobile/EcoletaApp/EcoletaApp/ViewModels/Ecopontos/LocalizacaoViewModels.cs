using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Map = Microsoft.Maui.Controls.Maps.Map;


namespace EcoletaApp.ViewModels.Ecopontos
{
    public class LocalizacaoViewModels : BaseViewModel
    {
        private Map meuMapa;

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
    }
}
