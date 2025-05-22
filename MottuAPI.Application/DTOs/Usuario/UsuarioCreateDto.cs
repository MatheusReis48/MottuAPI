using System;

namespace MottuAPI.Application.DTOs.Usuario
{
    public class UsuarioCreateDto
    {
        public int IdTipoUsuario { get; set; }
        public int? IdFilialAssociada { get; set; }
        public string NomeCompletoUsuario { get; set; }
        public string LoginUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
    }
}
