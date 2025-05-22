using System;

namespace MottuAPI.Domain.Entities
{
    public class Patio
    {
        public int IdPatio { get; set; }
        public int IdFilial { get; set; }
        public string NomePatio { get; set; }
        public string DescricaoPatio { get; set; }
        public int? CapacidadeTotalMotos { get; set; }
        public decimal? DimensoesPatioMetrosQuadrados { get; set; }
        public string LayoutPatioImgUrl { get; set; }
        public DateTime DataCadastro { get; set; }
        
        // Relacionamentos
        public Filial Filial { get; set; }
        public ICollection<AreaPatio> AreasPatio { get; set; }
        public ICollection<DadoEventoVisaoComputacional> DadosEventoVisaoComputacional { get; set; }
    }
}
