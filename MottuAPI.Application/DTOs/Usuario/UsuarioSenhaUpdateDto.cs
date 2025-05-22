using System;

namespace MottuAPI.Application.DTOs.Usuario
{
    public class UsuarioSenhaUpdateDto
    {
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmacaoNovaSenha { get; set; }
    }
}
