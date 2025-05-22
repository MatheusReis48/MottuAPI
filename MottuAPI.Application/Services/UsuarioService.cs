using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Usuario;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<UsuarioDto> GetUsuarioByIdAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<UsuarioDto> GetUsuarioByLoginAsync(string login)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuariosByTipoAsync(int idTipoUsuario)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioDto>> GetUsuariosByFilialAsync(int idFilial)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioUpdateDto usuarioDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUsuarioSenhaAsync(int id, UsuarioSenhaUpdateDto senhaDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }
    }
}
