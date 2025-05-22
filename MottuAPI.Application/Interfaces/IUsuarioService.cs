using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Usuario;

namespace MottuAPI.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();
        Task<UsuarioDto> GetUsuarioByIdAsync(int id);
        Task<UsuarioDto> GetUsuarioByLoginAsync(string login);
        Task<IEnumerable<UsuarioDto>> GetUsuariosByTipoAsync(int idTipoUsuario);
        Task<IEnumerable<UsuarioDto>> GetUsuariosByFilialAsync(int idFilial);
        Task<UsuarioDto> CreateUsuarioAsync(UsuarioCreateDto usuarioDto);
        Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioUpdateDto usuarioDto);
        Task<bool> UpdateUsuarioSenhaAsync(int id, UsuarioSenhaUpdateDto senhaDto);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
