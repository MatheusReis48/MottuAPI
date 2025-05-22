using System;

namespace MottuAPI.Domain.Entities
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string NomeTipoUsuario { get; set; }
        public string DescricaoTipoUsuario { get; set; }
        
        // Relacionamentos
        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<PermissaoTipoUsuario> PermissoesTipoUsuario { get; set; }
    }
}
