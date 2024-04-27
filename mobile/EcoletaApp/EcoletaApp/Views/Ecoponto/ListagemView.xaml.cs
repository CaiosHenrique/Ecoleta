using EcoletaApp.ViewModels.Ecopontos;

namespace EcoletaApp.Views.Ecoponto;

public partial class ListagemView : ContentPage
{
	ListagemEcopontoViewModel viewModel;

	public ListagemView()
	{
        InitializeComponent();

		viewModel = new ListagemEcopontoViewModel();
		BindingContext = viewModel;
		Title = "Ecopontos - EcoletaApp ";

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_  = viewModel.ObterEcopontos();
    }

}