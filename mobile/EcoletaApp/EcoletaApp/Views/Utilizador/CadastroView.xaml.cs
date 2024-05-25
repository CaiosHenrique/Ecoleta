using EcoletaApp.ViewModels.Utililizador;

namespace EcoletaApp.Views.Utilizador;

public partial class CadastroView : ContentPage
{
    utlizadorViewModel viewModel;
	public CadastroView()
	{
		InitializeComponent();

		viewModel = new utlizadorViewModel();
		BindingContext = viewModel;
	}
}