using EcoletaApp.ViewModels.Brindes;

namespace EcoletaApp.Views.Brinde;

public partial class ExibirBrindeView : ContentPage
{
	ExibirBrindesViewModel viewModel;
    public ExibirBrindeView()
	{
		viewModel = new ExibirBrindesViewModel();
		BindingContext = viewModel;
		Title = "Brinde - Ecoleta";

		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		_ = viewModel.ObterBrindes();
    }

}