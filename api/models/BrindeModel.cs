namespace api.Models
{
    public class BrindeModel
    {
        public int IdBrinde { get; set; }
        public string Nome { get; set; }
        public char Cadastro { get; set; }
        public DateTime Validade { get; set; }
        public int Quantidade { get; set; }
        public int Saldo { get; set; }
        public int ValorEcopoints { get; set; }
    }
}