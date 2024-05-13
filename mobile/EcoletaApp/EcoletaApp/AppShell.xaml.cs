using EcoletaApp.Views.Ecoponto;

namespace EcoletaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadEcopontoView", typeof(CadastroView));

        }
    }
}
