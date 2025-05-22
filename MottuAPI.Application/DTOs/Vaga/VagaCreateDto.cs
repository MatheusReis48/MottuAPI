using System;

namespace MottuAPI.Application.DTOs.Vaga
{
    public class VagaCreateDto
    {
        public int IdAreaPatio { get; set; }
        public string CodigoVaga { get; set; }
        public string TipoVaga { get; set; }
        public decimal? CoordenadaXPatio { get; set; }
        public decimal? CoordenadaYPatio { get; set; }
        public decimal? CoordenadaZPatio { get; set; }
        public string PoligonoVagaGeoJson { get; set; }
        public string StatusVaga { get; set; }
    }
}
