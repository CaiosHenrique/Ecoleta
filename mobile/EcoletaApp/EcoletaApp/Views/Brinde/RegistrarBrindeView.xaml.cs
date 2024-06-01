using EcoletaApp.ViewModels.Brindes;

namespace EcoletaApp.Views.Brinde;

public partial class RegistrarBrindeView : ContentPage
{
	RegistrarBrindeViewModel viewModel;
	public RegistrarBrindeView()
	{
		InitializeComponent();

		viewModel = new RegistrarBrindeViewModel();
		BindingContext = viewModel;
		Title = "Registrar Brindes";
	}
}