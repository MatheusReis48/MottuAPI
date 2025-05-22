using System;

namespace MottuAPI.Domain.Entities
{
    public class DadoEventoVisaoComputacional
    {
        public int IdEventoVC { get; set; }
        public int? IdPatio { get; set; }
        public string IdCamera { get; set; }
        public DateTime TimestampEvento { get; set; }
        public string PlacaDetectada { get; set; }
        public string ModeloDetectado { get; set; }
        public string CoordenadasDeteccaoImg { get; set; }
        public string UrlSnapshotImg { get; set; }
        public decimal? ConfiancaDeteccao { get; set; }
        public string StatusProcessamento { get; set; }
        public int? IdMotoAssociada { get; set; }
        public int? IdVagaAssociada { get; set; }
        
        // Relacionamentos
        public Patio Patio { get; set; }
        public Moto MotoAssociada { get; set; }
        public Vaga VagaAssociada { get; set; }
    }
}
