using System;

namespace MottuAPI.Domain.Entities
{
    public class AreaPatio
    {
        public int IdAreaPatio { get; set; }
        public int IdPatio { get; set; }
        public string NomeArea { get; set; }
        public string DescricaoArea { get; set; }
        public string TipoArea { get; set; }
        
        // Relacionamentos
        public Patio Patio { get; set; }
        public ICollection<Vaga> Vagas { get; set; }
    }
}
