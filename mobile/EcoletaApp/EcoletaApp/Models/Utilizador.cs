using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
    public class Utilizador
    {
        [Key]
        public int IdUtilizador { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool SituacaoEmail { get; set; }

        public int TotalEcoPoints { get; set; } = 0;

        [ForeignKey("TotalEcoPoints")]
        public Ecopoints EcoPoints { get; set; } = new Ecopoints();
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime? DataAcesso { get; set; } //using System;

        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema
        public string PasswordString { get; set; } = string.Empty;

    }
}
