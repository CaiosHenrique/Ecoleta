using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
    public  class Ecopoints
    {
        [Key]
        public int IdMaterial { get; set; }
        public char OrdemGrandeza { get; set; }
        public int Quantidade { get; set; }
        public int EcoPointsTotais { get; set; }
    }
}
