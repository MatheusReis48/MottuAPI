using System;

namespace MottuAPI.Domain.Entities
{
    public class StatusMotoCatalogo
    {
        public int IdStatusMoto { get; set; }
        public string DescricaoStatus { get; set; }
        public string CorIndicativaStatus { get; set; }
        
        // Relacionamentos
        public ICollection<Moto> Motos { get; set; }
        public ICollection<HistoricoStatusMoto> HistoricoStatusMotosAnteriores { get; set; }
        public ICollection<HistoricoStatusMoto> HistoricoStatusMotosNovos { get; set; }
    }
}
