using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class MateriaisModel
    {   
        [Key]
        public int IdMaterial { get; set; }
        public string DescricaoMaterial { get; set; }
        public int Classe { get; set; }
        
    }
}