using System;

namespace MottuAPI.Domain.Entities
{
    public class HistoricoLocalizacaoMoto
    {
        public int IdHistoricoLoc { get; set; }
        public int IdMoto { get; set; }
        public int? IdVagaAnterior { get; set; }
        public int? IdVagaNova { get; set; }
        public decimal? LatitudeRegistro { get; set; }
        public decimal? LongitudeRegistro { get; set; }
        public DateTime TimestampRegistro { get; set; }
        public string FonteDadoLocalizacao { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        
        // Relacionamentos
        public Moto Moto { get; set; }
        public Vaga VagaAnterior { get; set; }
        public Vaga VagaNova { get; set; }
        public Usuario UsuarioRegistro { get; set; }
    }
}
