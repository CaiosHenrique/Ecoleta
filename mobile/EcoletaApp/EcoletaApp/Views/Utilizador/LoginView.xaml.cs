using EcoletaApp.ViewModels.Utililizador;

namespace EcoletaApp.Views.Utilizador;

public partial class LoginView : ContentPage
{
    utlizadorViewModel utilizadorViewModel;

	public LoginView()
	{
        InitializeComponent();

        utilizadorViewModel = new utlizadorViewModel();
        BindingContext = utilizadorViewModel;

	}

}