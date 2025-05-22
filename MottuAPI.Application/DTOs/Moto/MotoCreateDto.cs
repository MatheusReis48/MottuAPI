using System;

namespace MottuAPI.Application.DTOs.Moto
{
    public class MotoCreateDto
    {
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
        public string ObservacoesMoto { get; set; }
    }
}
