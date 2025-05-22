using System;

namespace MottuAPI.Application.DTOs.Usuario
{
    public class UsuarioUpdateDto
    {
        public int IdTipoUsuario { get; set; }
        public int? IdFilialAssociada { get; set; }
        public string NomeCompletoUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public string StatusUsuario { get; set; }
    }
}
