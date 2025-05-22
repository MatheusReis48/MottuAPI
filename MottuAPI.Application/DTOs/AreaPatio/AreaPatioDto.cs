using System;

namespace MottuAPI.Application.DTOs.AreaPatio
{
    public class AreaPatioDto
    {
        public int IdAreaPatio { get; set; }
        public int IdPatio { get; set; }
        public string NomeArea { get; set; }
        public string DescricaoArea { get; set; }
        public string TipoArea { get; set; }
        
        // Propriedades de navegação para exibição
        public string NomePatio { get; set; }
        public int QuantidadeVagas { get; set; }
        public int QuantidadeVagasOcupadas { get; set; }
    }
}
