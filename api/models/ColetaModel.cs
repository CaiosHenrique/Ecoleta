namespace api.models
{
    public class ColetaModel
    {
        public int IdColeta { get; set; }
        public int IdEcoponto { get; set; }
        public int IdUtilizador { get; set; }
        public DateTime DataColeta { get; set; }
        public float TotalEcopoints { get; set; }
        public int Peso { get; set; }
    }
}