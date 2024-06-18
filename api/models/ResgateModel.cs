using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ResgateModel
    {
        [Key]
        public int IdResgate { get; set; }
        [ForeignKey("IdUtilizador")]
        public int IdUtilizador { get; set; }
        [ForeignKey("IdBrinde")]
        public int IdBrinde { get; set; }
        public DateTime DataResgate { get; set; }
    }
}