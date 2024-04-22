using EcoletaApp.ViewModels.Ecopontos;

namespace EcoletaApp.Views;

public partial class EcopontoView : ContentPage
{
	EcopontoViewModel viewModel;
	public EcopontoView()
	{
		InitializeComponent();

		viewModel = new EcopontoViewModel();
		BindingContext = viewModel;
	}
		
	

}