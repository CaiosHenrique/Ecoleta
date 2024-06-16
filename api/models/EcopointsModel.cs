using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class EcopointsModel
    {  
       
      
       [Key]
       public int TotalEcoPoints { get; set; } = 0;

        [ForeignKey("IdUtilizador")]
        public int IdUtilizador { get; set; }

        [ForeignKey("IdMaterial")]
       public int IdMaterial { get; set; }

      
    }
}