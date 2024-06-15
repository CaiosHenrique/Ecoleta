using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ColetaModel
    {         
        [Key]
        public int IdColeta { get; set; }
       // [ForeignKey ("IdEcoponto")]
        public int IdEcoponto { get; set; }
       // [ForeignKey ("IdUtilizador")]
        public int IdUtilizador { get; set; }
         public int  CodigoEcoponto {get;set;}
         public int  CodigoUtilizador { get; set; }
        public DateTime DataColeta { get; set; }
        public float TotalEcopoints { get; set; }
        public Double Peso { get; set; }
          public string SituacaoColeta { get; set; } = string.Empty;
    }
}