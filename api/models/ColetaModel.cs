namespace api.Models
{
    public class ColetaModel
    {
        public int IdColeta { get; set; }
        public int IdEcoponto { get; set; }
         public int  CodigoEcoponto {get;set;}
        public int IdUtilizador { get; set; }
         public int  CodigoUltilizador { get; set; }
        public DateTime DataColeta { get; set; }
        public float TotalEcopoints { get; set; }
        public Double Peso { get; set; }
          public string SituacaoColeta { get; set; }
    }
}