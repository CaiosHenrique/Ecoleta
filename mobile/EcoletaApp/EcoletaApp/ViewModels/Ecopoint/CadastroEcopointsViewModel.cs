using Ecoleta.Models.Enuns;
using EcoletaApp.Models;
using EcoletaApp.Services.EcopointsService;
using EcoletaApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ecoleta.ViewModels.Ecopoint
{
    [QueryProperty("EcopointSelecionadoId", "eId")]
    public  class CadastroEcopointsViewModel: BaseViewModel
    {
        private readonly EcopointsService eService;


        public CadastroEcopointsViewModel()
        { 
            eService = new EcopointsService();

            _ = ObterMateriais();

            SalvarCommand = new Command(async () => { await SalvarEcopoints(); });
            CancelarCommand = new Command(async () => { await Cancelarcadastro(); });
        }
        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; }

        #region Atributos
        private int idMaterial;
        private char ordemGrandeza;
        private int quantidade;
        private int totalEcopoints;
        private int utilizadorId;

        public int IdMaterial { get { return idMaterial; } set { if (value != null) { idMaterial = value; OnPropertyChanged(nameof(IdMaterial)); } } }
        public char OrdemGrandeza { get { return ordemGrandeza; } set { if (value != null) { ordemGrandeza = value; OnPropertyChanged(nameof(OrdemGrandeza)); } } }
        public int Quantidade { get { return quantidade; } set { if (value != null) { quantidade = value; OnPropertyChanged(nameof(Quantidade)); } } }
        public int TotalEcopoints { get { return totalEcopoints; } set { if (value != null) { totalEcopoints = value; OnPropertyChanged(nameof(TotalEcopoints)); } } }
        public int UtilizadorId { get { return utilizadorId; } set { if (value != null) { utilizadorId = value; OnPropertyChanged(nameof(UtilizadorId)); } } }

    
        private ObservableCollection<Materiais> tipoMaterial;
        public ObservableCollection<Materiais> TipoMaterial { get { return tipoMaterial; } set { if (value != null) { tipoMaterial = value; OnPropertyChanged(nameof(TipoMaterial)); } } }

        private Materiais selecionarMaterial;
        public Materiais SelecionarMaterial { get { return selecionarMaterial; } set { if (value != null) { selecionarMaterial = value; OnPropertyChanged(nameof(SelecionarMaterial)); } } }

        private string ecopointSelecionadoId;
        public string EcopointSelecionadoId { get => ecopointSelecionadoId; set { if (value != null) { ecopointSelecionadoId = Uri.UnescapeDataString(value); CarregarEcopointsAsync(); } } }


        #endregion


        public async Task ObterMateriais()
        {
            try
            {
             #region materias ununs
                TipoMaterial =
              [
                  new Materiais() { IdMaterial = 1, DescricaoMaterial = "Papel/Papelão", Enuns = MateriaisEnuns.Papel, Classe = 1 },
                new Materiais() { IdMaterial = 2, DescricaoMaterial = "Plastico", Enuns = MateriaisEnuns.Plastico, Classe = 2 },
                new Materiais() { IdMaterial = 3, DescricaoMaterial = "Vidro", Enuns = MateriaisEnuns.Vidro, Classe = 3 },
                new Materiais() { IdMaterial = 4, DescricaoMaterial = "Metal", Enuns = MateriaisEnuns.Metal, Classe = 4 },
                new Materiais() { IdMaterial = 5, DescricaoMaterial = "Organico", Enuns = MateriaisEnuns.Organico, Classe = 5 },
                new Materiais() { IdMaterial = 6, DescricaoMaterial = "Eletronico", Enuns = MateriaisEnuns.Eletronico, Classe = 6 },
                new Materiais() { IdMaterial = 7, DescricaoMaterial = "Pilha", Enuns = MateriaisEnuns.Pilha, Classe = 7 },
                new Materiais() { IdMaterial = 8, DescricaoMaterial = "Bateria", Enuns = MateriaisEnuns.Bateria, Classe = 8 },
                new Materiais() { IdMaterial = 9, DescricaoMaterial = "Oleo", Enuns = MateriaisEnuns.Oleo, Classe = 9 },
                new Materiais() { IdMaterial = 10, DescricaoMaterial = "Medicamento", Enuns = MateriaisEnuns.Medicamento, Classe = 10 },
                new Materiais() { IdMaterial = 11, DescricaoMaterial = "Gesso", Enuns = MateriaisEnuns.Medicamento, Classe = 11 },
                new Materiais() { IdMaterial = 12, DescricaoMaterial = "Material_Construcao", Enuns = MateriaisEnuns.Medicamento, Classe = 12 },
                new Materiais() { IdMaterial = 13, DescricaoMaterial = "Madeira", Enuns = MateriaisEnuns.Medicamento, Classe = 13 },
                new Materiais() { IdMaterial = 14, DescricaoMaterial = "Isopor", Enuns = MateriaisEnuns.Medicamento, Classe = 14 },
                new Materiais() { IdMaterial = 15, DescricaoMaterial = "Outros", Enuns = MateriaisEnuns.Outro, Classe = 15 },
            ];
                #endregion

                OnPropertyChanged(nameof(TipoMaterial));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }

        public async Task SalvarEcopoints()
        {
            try
            { 
                Ecopoints model = new Ecopoints();
                { 
                    IdMaterial = this.IdMaterial;
                    OrdemGrandeza = this.OrdemGrandeza;
                    Quantidade = this.Quantidade;
                    TotalEcopoints = this.TotalEcopoints;
                    utilizadorId = this.UtilizadorId;
                    model.Material = (MateriaisEnuns)selecionarMaterial.IdMaterial;
                     
                };
                if (model.IdMaterial == 0)
                    await eService.PostRegistrarEcopointsAsync(model);
                else if (model.IdMaterial != 0)
                    await eService.PutEcopointsAsync(model);

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "OK");

                await Shell.Current.GoToAsync("..");
            
            }
            catch (Exception ex)
            {
                await Shell.Current.GoToAsync("..");

                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }

        public async Task Cancelarcadastro()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task CarregarEcopointsAsync()
        {
            try
            {
                Ecopoints e = await eService.GetEcopointsAsync(int.Parse(EcopointSelecionadoId));

                this.IdMaterial = e.IdMaterial;
                this.OrdemGrandeza = e.OrdemGrandeza;
                this.Quantidade = e.Quantidade;
                this.TotalEcopoints = e.TotalEcoPoints;
                this.UtilizadorId = e.UtilizadorId;

                SelecionarMaterial = this.TipoMaterial.FirstOrDefault(m => m.IdMaterial == (int)e.Material);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }

    }
}
