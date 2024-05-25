using EcoletaApp.ViewModels.Coletas;

namespace EcoletaApp.Views.Coletas;

public partial class ExibirColetasView : ContentPage
{
    ExibirColetasViewModel viewModel;
    public ExibirColetasView()
	{
        viewModel = new ExibirColetasViewModel();
        BindingContext = viewModel;
        Title = "Coleta - Ecoleta";


        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _= viewModel.ObterColetas();
    }
}