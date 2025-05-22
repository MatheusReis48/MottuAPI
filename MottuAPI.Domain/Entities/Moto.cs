using System;

namespace MottuAPI.Domain.Entities
{
    public class Moto
    {
        public int IdMoto { get; set; }
        public int IdTipoMoto { get; set; }
        public string PlacaMoto { get; set; }
        public string ChassiMoto { get; set; }
        public string RenavamMoto { get; set; }
        public int? AnoFabricacaoMoto { get; set; }
        public int? AnoModeloMoto { get; set; }
        public string CorMoto { get; set; }
        public int? IdFilialBase { get; set; }
        public int IdStatusMotoAtual { get; set; }
        public int? IdVagaAtual { get; set; }
        public decimal? UltimaLocalizacaoLatitude { get; set; }
        public decimal? UltimaLocalizacaoLongitude { get; set; }
        public DateTime? TimestampUltimaLocalizacao { get; set; }
        public string ObservacoesMoto { get; set; }
        public DateTime DataCadastroMoto { get; set; }
        public DateTime? DataUltimaAtualizacaoMoto { get; set; }
        
        // Relacionamentos
        public TipoMoto TipoMoto { get; set; }
        public Filial FilialBase { get; set; }
        public StatusMotoCatalogo StatusMotoAtual { get; set; }
        public Vaga VagaAtual { get; set; }
        public ICollection<HistoricoLocalizacaoMoto> HistoricoLocalizacaoMotos { get; set; }
        public ICollection<HistoricoStatusMoto> HistoricoStatusMotos { get; set; }
        public ICollection<DadoEventoVisaoComputacional> DadosEventoVisaoComputacional { get; set; }
    }
}
