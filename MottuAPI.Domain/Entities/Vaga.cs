using System;

namespace MottuAPI.Domain.Entities
{
    public class Vaga
    {
        public int IdVaga { get; set; }
        public int IdAreaPatio { get; set; }
        public string CodigoVaga { get; set; }
        public string TipoVaga { get; set; }
        public decimal? CoordenadaXPatio { get; set; }
        public decimal? CoordenadaYPatio { get; set; }
        public decimal? CoordenadaZPatio { get; set; }
        public string PoligonoVagaGeoJson { get; set; }
        public string StatusVaga { get; set; }
        
        // Relacionamentos
        public AreaPatio AreaPatio { get; set; }
        public Moto Moto { get; set; }
        public ICollection<HistoricoLocalizacaoMoto> HistoricoLocalizacaoMotosAnteriores { get; set; }
        public ICollection<HistoricoLocalizacaoMoto> HistoricoLocalizacaoMotosNovas { get; set; }
        public ICollection<DadoEventoVisaoComputacional> DadosEventoVisaoComputacional { get; set; }
    }
}
