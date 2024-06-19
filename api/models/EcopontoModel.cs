using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace api.Models
{
    public class EcopontoModel
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
                
        public int Numero { get; set; } 

        public int CEP { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }


        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [NotMapped] // using System.ComponentModel.DataAnnotations.Schema
        public string PasswordString { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
