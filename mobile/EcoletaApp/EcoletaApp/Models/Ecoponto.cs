using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
     public class Ecoponto
    {
        [Key]
        public int IdEcoponto { get; set; }

        public string Nome { get; set; } = string.Empty;

        public int CNPJ { get; set; }

        public string RazaoSocial { get; set; } = string.Empty;

        public string Logradouro { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string Cidade { get; set; } = string.Empty;

        public string UF { get; set; } = string.Empty;

        public int CEP { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public string Username { get; set; } = string.Empty;
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }

        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema
        public string PasswordString { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
