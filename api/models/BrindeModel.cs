using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class BrindeModel
    {
        [Key]
        public int IdBrinde { get; set; }
        public  string DescricaoBrinde { get; set; }
        public string NomeBrinde { get; set; }
        public char Cadastro { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
        public int Saldo { get; set; }
        public int ValorEcopoints { get; set; }
    }
}