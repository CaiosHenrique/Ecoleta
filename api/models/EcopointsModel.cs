using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace api.Models
{
    public class EcopointsModel
    {  
        [Key]
       public int IdMaterial { get; set; }
       public char OrdemGrandeza { get; set; }
       public int Quantidade { get; set; }
       public int TotalEcoPoints { get; set; } = 0;

        [ForeignKey("IdUtilizador")]
        public int IdUtilizador { get; set; }

       public ObservableCollection<UtilizadorModel> Utilizador { get; set; }

    //      [Key]
    //    public int IdMaterial { get; set; }
    //     // mudar

    //     [Key]
    //    public int TotalEcoPoints { get; set; } = 0;
    //            // mudar
    //     [ForeignKey("IdUtilizador")]
    //     public int IdUtilizador { get; set; }
    //    public string Metrica { get; set; }
    //    public int Quantidade { get; set; }

    //     // mudar
    //     public ObservableCollection<UtilizadorModel> Utilizador { get; set; }
      
    }
}