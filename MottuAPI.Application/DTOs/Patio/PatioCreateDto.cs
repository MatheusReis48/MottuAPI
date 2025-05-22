using System;

namespace MottuAPI.Application.DTOs.Patio
{
    public class PatioCreateDto
    {
        public int IdFilial { get; set; }
        public string NomePatio { get; set; }
        public string DescricaoPatio { get; set; }
        public int? CapacidadeTotalMotos { get; set; }
        public decimal? DimensoesPatioMetrosQuadrados { get; set; }
        public string LayoutPatioImgUrl { get; set; }
    }
}
