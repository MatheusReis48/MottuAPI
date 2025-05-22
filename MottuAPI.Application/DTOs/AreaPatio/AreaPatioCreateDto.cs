using System;

namespace MottuAPI.Application.DTOs.AreaPatio
{
    public class AreaPatioCreateDto
    {
        public int IdPatio { get; set; }
        public string NomeArea { get; set; }
        public string DescricaoArea { get; set; }
        public string TipoArea { get; set; }
    }
}
