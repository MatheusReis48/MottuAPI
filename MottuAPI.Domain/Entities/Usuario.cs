using System;

namespace MottuAPI.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? IdFilialAssociada { get; set; }
        public string NomeCompletoUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaHashUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public string StatusUsuario { get; set; }
        public DateTime DataCadastroUsuario { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        
        // Relacionamentos
        public TipoUsuario TipoUsuario { get; set; }
        public Filial FilialAssociada { get; set; }
        public ICollection<HistoricoLocalizacaoMoto> HistoricoLocalizacaoMotos { get; set; }
        public ICollection<HistoricoStatusMoto> HistoricoStatusMotos { get; set; }
    }
}
