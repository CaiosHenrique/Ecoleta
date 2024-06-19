using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models.Enuns;
using api.Models;

namespace api.Models
{
    public class ColetaModel
    {         
        [Key]
        public int IdColeta { get; set; }
        [ForeignKey("IdEcoponto")]
        public int IdEcoponto { get; set; }
        [ForeignKey("IdUtilizador")]
        public int IdUtilizador { get; set; }
        public Materiais Classe { get; set; }
        public DateTime DataColeta { get; set; }
        public Double Peso { get; set; }
        public string SituacaoColeta { get; set; } = string.Empty;
    }
}