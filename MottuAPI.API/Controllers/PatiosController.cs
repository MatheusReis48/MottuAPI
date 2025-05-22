using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MottuAPI.Application.DTOs.Patio;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.API.Controllers
{
    /// <summary>
    /// API para gerenciamento de pátios
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PatiosController : ControllerBase
    {
        private readonly IPatioService _patioService;
        private readonly ILogger<PatiosController> _logger;

        /// <summary>
        /// Construtor do controller de pátios
        /// </summary>
        /// <param name="patioService">Serviço de pátios</param>
        /// <param name="logger">Logger</param>
        public PatiosController(IPatioService patioService, ILogger<PatiosController> logger)
        {
            _patioService = patioService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todos os pátios cadastrados
        /// </summary>
        /// <returns>Lista de pátios</returns>
        /// <response code="200">Retorna a lista de pátios</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PatioDto>>> GetAll()
        {
            try
            {
                var patios = await _patioService.GetAllPatiosAsync();
                return Ok(patios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os pátios");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém um pátio pelo seu ID
        /// </summary>
        /// <param name="id">ID do pátio</param>
        /// <returns>Dados do pátio</returns>
        /// <response code="200">Retorna o pátio solicitado</response>
        /// <response code="404">Pátio não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PatioDto>> GetById(int id)
        {
            try
            {
                var patio = await _patioService.GetPatioByIdAsync(id);
                if (patio == null)
                    return NotFound($"Pátio com ID {id} não encontrado");

                return Ok(patio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter pátio com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém pátios por filial
        /// </summary>
        /// <param name="idFilial">ID da filial</param>
        /// <returns>Lista de pátios da filial</returns>
        /// <response code="200">Retorna a lista de pátios da filial</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("filial/{idFilial}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PatioDto>>> GetByFilial(int idFilial)
        {
            try
            {
                var patios = await _patioService.GetPatiosByFilialAsync(idFilial);
                return Ok(patios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter pátios da filial {idFilial}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Cadastra um novo pátio
        /// </summary>
        /// <param name="patioDto">Dados do pátio</param>
        /// <returns>Pátio cadastrado</returns>
        /// <response code="201">Pátio cadastrado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PatioDto>> Create([FromBody] PatioCreateDto patioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novoPatio = await _patioService.CreatePatioAsync(patioDto);
                return CreatedAtAction(nameof(GetById), new { id = novoPatio.IdPatio }, novoPatio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar pátio");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Atualiza um pátio existente
        /// </summary>
        /// <param name="id">ID do pátio</param>
        /// <param name="patioDto">Dados atualizados do pátio</param>
        /// <returns>Pátio atualizado</returns>
        /// <response code="200">Pátio atualizado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Pátio não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PatioDto>> Update(int id, [FromBody] PatioUpdateDto patioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var patioAtualizado = await _patioService.UpdatePatioAsync(id, patioDto);
                if (patioAtualizado == null)
                    return NotFound($"Pátio com ID {id} não encontrado");

                return Ok(patioAtualizado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar pátio com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Remove um pátio
        /// </summary>
        /// <param name="id">ID do pátio</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Pátio removido com sucesso</response>
        /// <response code="404">Pátio não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _patioService.DeletePatioAsync(id);
                if (!resultado)
                    return NotFound($"Pátio com ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir pátio com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }
    }
}
