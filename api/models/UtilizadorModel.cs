using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UtilizadorModel
    {   
        [Key]
        public int IdUtilizador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool SituacaoEmail{ get; set; }
    }
}