using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
    public class Materiais
    {
        [Key]
        public int IdMaterial { get; set; }
        public string DescricaoMaterial { get; set; } = string.Empty;
        public int Classe { get; set; }

    }
}
