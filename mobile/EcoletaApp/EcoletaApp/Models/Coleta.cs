using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
    public class Coleta
    {
        [Key]
        public int IdColeta { get; set; }
        public int IdEcoponto { get; set; }
        public int IdUtilizador { get; set; }
        public int CodigoEcoponto { get; set; }
        public int CodigoUtilizador { get; set; }
        public DateTime DataColeta { get; set; }
        public float TotalEcopoints { get; set; }
        public Double Peso { get; set; }
        public string SituacaoColeta { get; set; } = string.Empty;
    }
}
