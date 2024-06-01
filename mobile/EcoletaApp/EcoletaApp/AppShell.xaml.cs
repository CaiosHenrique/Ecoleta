using EcoletaApp.Views.Ecoponto;
using EcoletaApp.Views.Utilizador;

namespace EcoletaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadEcopontoView", typeof(Views.Ecoponto.CadastroView));
            Routing.RegisterRoute("cadColetaView", typeof(Views.Coletas.RegistrarColetasView));
            Routing.RegisterRoute("cadBrindeView", typeof(Views.Brinde.RegistrarBrindeView));
      
        }
    }
}
