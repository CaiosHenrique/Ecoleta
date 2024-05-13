using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace api.Models
{
    public class EcopontoModel
    {   
        [Key]
        public int IdEcoponto { get; set; }

        public string Nome { get; set; }

        public int CNPJ { get; set; }

        public string RazaoSocial { get; set; }

        public string Logradouro { get; set; }

        public string Endereco { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public int CEP { get; set; }

        public int Latitude { get; set; }

        public int Longitude { get; set; }


        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; } 
        public byte[]? PasswordSalt { get; set; }

        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema
        public string PasswordString { get; set; } = string.Empty;

    }
}
