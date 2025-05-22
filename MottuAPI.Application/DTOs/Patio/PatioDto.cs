using System;

namespace MottuAPI.Application.DTOs.Patio
{
    public class PatioDto
    {
        public int IdPatio { get; set; }
        public int IdFilial { get; set; }
        public string NomePatio { get; set; }
        public string DescricaoPatio { get; set; }
        public int? CapacidadeTotalMotos { get; set; }
        public decimal? DimensoesPatioMetrosQuadrados { get; set; }
        public string LayoutPatioImgUrl { get; set; }
        public DateTime DataCadastro { get; set; }
        
        // Propriedades de navegação para exibição
        public string NomeFilial { get; set; }
        public int QuantidadeAreas { get; set; }
        public int QuantidadeVagas { get; set; }
        public int QuantidadeVagasOcupadas { get; set; }
    }
}
