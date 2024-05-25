using EcoletaApp.ViewModels;
using EcoletaApp.ViewModels.Coletas;

namespace EcoletaApp.Views.Coletas;

public partial class RegistrarColetasView : ContentPage
{
	RegistrarColetaViewModel viewModel;
	public RegistrarColetasView()
	{
		InitializeComponent();

		viewModel = new RegistrarColetaViewModel();
		BindingContext = viewModel;
		Title = "Registrar Coleta";
	}
}