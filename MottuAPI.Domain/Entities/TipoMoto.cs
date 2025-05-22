using System;

namespace MottuAPI.Domain.Entities
{
    public class TipoMoto
    {
        public int IdTipoMoto { get; set; }
        public string ModeloMoto { get; set; }
        public string MarcaMoto { get; set; }
        public int? AnoFabricacaoModelo { get; set; }
        public string DescricaoTipoMoto { get; set; }
        public string UrlImagemModelo { get; set; }
        
        // Relacionamentos
        public ICollection<Moto> Motos { get; set; }
    }
}
