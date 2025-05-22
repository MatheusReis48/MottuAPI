using System;

namespace MottuAPI.Domain.Entities
{
    public class PermissaoTipoUsuario
    {
        public int IdPermissaoTipoUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string NomePermissao { get; set; }
        public bool Permitido { get; set; }
        
        // Relacionamentos
        public TipoUsuario TipoUsuario { get; set; }
    }
}
