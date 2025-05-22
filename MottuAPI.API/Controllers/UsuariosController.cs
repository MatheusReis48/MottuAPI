using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MottuAPI.Application.DTOs.Usuario;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.API.Controllers
{
    /// <summary>
    /// API para gerenciamento de usuários
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<UsuariosController> _logger;

        /// <summary>
        /// Construtor do controller de usuários
        /// </summary>
        /// <param name="usuarioService">Serviço de usuários</param>
        /// <param name="logger">Logger</param>
        public UsuariosController(IUsuarioService usuarioService, ILogger<UsuariosController> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os usuários cadastrados
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Retorna a lista de usuários</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os usuários");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Retorna o usuário solicitado</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                if (usuario == null)
                    return NotFound($"Usuário com ID {id} não encontrado");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter usuário com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém um usuário pelo login
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Retorna o usuário solicitado</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("login/{login}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioDto>> GetByLogin(string login)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByLoginAsync(login);
                if (usuario == null)
                    return NotFound($"Usuário com login '{login}' não encontrado");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter usuário com login '{login}'");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém usuários por tipo
        /// </summary>
        /// <param name="idTipoUsuario">ID do tipo de usuário</param>
        /// <returns>Lista de usuários do tipo especificado</returns>
        /// <response code="200">Retorna a lista de usuários do tipo</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("tipo/{idTipoUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetByTipo(int idTipoUsuario)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosByTipoAsync(idTipoUsuario);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter usuários do tipo {idTipoUsuario}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém usuários por filial
        /// </summary>
        /// <param name="idFilial">ID da filial</param>
        /// <returns>Lista de usuários da filial</returns>
        /// <response code="200">Retorna a lista de usuários da filial</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("filial/{idFilial}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetByFilial(int idFilial)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuariosByFilialAsync(idFilial);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter usuários da filial {idFilial}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuarioDto">Dados do usuário</param>
        /// <returns>Usuário cadastrado</returns>
        /// <response code="201">Usuário cadastrado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioDto>> Create([FromBody] UsuarioCreateDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novoUsuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);
                return CreatedAtAction(nameof(GetById), new { id = novoUsuario.IdUsuario }, novoUsuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="usuarioDto">Dados atualizados do usuário</param>
        /// <returns>Usuário atualizado</returns>
        /// <response code="200">Usuário atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioDto>> Update(int id, [FromBody] UsuarioUpdateDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioAtualizado = await _usuarioService.UpdateUsuarioAsync(id, usuarioDto);
                if (usuarioAtualizado == null)
                    return NotFound($"Usuário com ID {id} não encontrado");

                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar usuário com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Atualiza a senha de um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="senhaDto">Dados da senha</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Senha atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPut("{id}/senha")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateSenha(int id, [FromBody] UsuarioSenhaUpdateDto senhaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultado = await _usuarioService.UpdateUsuarioSenhaAsync(id, senhaDto);
                if (!resultado)
                    return NotFound($"Usuário com ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar senha do usuário com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Remove um usuário
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Usuário removido com sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _usuarioService.DeleteUsuarioAsync(id);
                if (!resultado)
                    return NotFound($"Usuário com ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir usuário com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }
    }
}
