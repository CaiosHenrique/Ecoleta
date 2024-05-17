using EcoletaApp.ViewModels.Ecopontos;

namespace EcoletaApp.Views.Ecoponto;

public partial class CadastroView : ContentPage
{
	private CadastroEcopontoViewModel cadViewModel;

    public CadastroView()
	{
		InitializeComponent();
	 
		cadViewModel = new CadastroEcopontoViewModel();
		BindingContext = cadViewModel;
		Title = "Novo Ecoponto";

    }
}