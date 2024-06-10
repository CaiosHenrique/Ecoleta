using Ecoleta.ViewModels.Ecopoint.ListagemEcopointsViewModel;

namespace Ecoleta.Views.Ecopoint;

public partial class listagemEcopointsView : ContentPage
{
	ListagemEcopointsViewModel viewModel;
	public listagemEcopointsView()
	{
		InitializeComponent();

        viewModel= new ListagemEcopointsViewModel();
		BindingContext = viewModel;
		Title = "Ecopoints";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ =  viewModel.ObterEcopoints();
    }
}