using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
    public class Brinde
    {
        [Key]
        public int IdBrinde { get; set; }
        public string DescricaoBrinde { get; set; } = string.Empty;
        public string NomeBrinde { get; set; } = string.Empty;
        public char Cadastro { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
        public int Saldo { get; set; }
        public int ValorEcopoints { get; set; }
    }
}
