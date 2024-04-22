using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoletaApp.Models
{
     public class Ecoponto
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

    }
}
