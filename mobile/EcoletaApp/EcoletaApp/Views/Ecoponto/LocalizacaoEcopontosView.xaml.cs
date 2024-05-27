using EcoletaApp.ViewModels.Ecopontos;

namespace EcoletaApp.Views.Ecoponto;

public partial class LocalizacaoEcopontosView : ContentPage
{
    LocalizacaoViewModels viewModels;
    public LocalizacaoEcopontosView()
	{
		InitializeComponent();


        viewModels = new LocalizacaoViewModels();
      //  viewModels.InicializarMapa();

        BindingContext = viewModels;
        viewModels.ExibirUsuariosnoMapa();
    }
}