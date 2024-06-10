using Ecoleta.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
    public class Ecopoints
    {
        [Key]
        public int IdMaterial { get; set; }
        public MateriaisEnuns? Material{  get; set; }  = new MateriaisEnuns();
        public char OrdemGrandeza { get; set; }
        public int Quantidade { get; set; }
        public int TotalEcoPoints { get; set; }

        public int UtilizadorId { get; set; }

        [ForeignKey("UtilizadorId")]
        public Utilizador Utilizador { get; set; } = new Utilizador();
    }
}
