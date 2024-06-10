using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        public UtilizadorModel Utilizador { get; set; }
      
    }
}