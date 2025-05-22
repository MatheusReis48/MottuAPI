using System;

namespace MottuAPI.Application.DTOs.Usuario
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public int? IdFilialAssociada { get; set; }
        public string NomeCompletoUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public string StatusUsuario { get; set; }
        public DateTime DataCadastroUsuario { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        
        // Propriedades de navegação para exibição
        public string NomeTipoUsuario { get; set; }
        public string NomeFilial { get; set; }
    }
}
