using System;

namespace MottuAPI.Domain.Entities
{
    public class HistoricoStatusMoto
    {
        public int IdHistoricoStatus { get; set; }
        public int IdMoto { get; set; }
        public int? IdStatusAnterior { get; set; }
        public int IdStatusNovo { get; set; }
        public DateTime TimestampMudancaStatus { get; set; }
        public int? IdUsuarioResponsavel { get; set; }
        public string MotivoMudanca { get; set; }
        
        // Relacionamentos
        public Moto Moto { get; set; }
        public StatusMotoCatalogo StatusAnterior { get; set; }
        public StatusMotoCatalogo StatusNovo { get; set; }
        public Usuario UsuarioResponsavel { get; set; }
    }
}
