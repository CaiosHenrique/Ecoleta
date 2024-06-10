using Ecoleta.ViewModels.Ecopoint;

namespace Ecoleta.Views.Ecopoint;

public partial class CadastrarEcopointsView : ContentPage
{
	private CadastroEcopointsViewModel	_model;
	public CadastrarEcopointsView()
	{
		InitializeComponent();

		Routing.RegisterRoute("cadEcopointsView", typeof(CadastrarEcopointsView));

		_=new CadastroEcopointsViewModel();
		BindingContext =_model;
		Title = "Cadastrar Ecopoints";
	}
}