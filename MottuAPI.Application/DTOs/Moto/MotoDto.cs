using System;

namespace MottuAPI.Application.DTOs.Moto
{
    public class MotoDto
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
        
        // Propriedades de navegação para exibição
        public string ModeloMoto { get; set; }
        public string MarcaMoto { get; set; }
        public string NomeFilial { get; set; }
        public string DescricaoStatus { get; set; }
        public string CodigoVaga { get; set; }
    }
}
