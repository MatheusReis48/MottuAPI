using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MottuAPI.Application.DTOs.AreaPatio;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AreasPatioController : ControllerBase
    {
        private readonly IAreaPatioService _areaPatioService;
        private readonly ILogger<AreasPatioController> _logger;

        public AreasPatioController(IAreaPatioService areaPatioService, ILogger<AreasPatioController> logger)
        {
            _areaPatioService = areaPatioService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todas as áreas de pátio cadastradas
        /// </summary>
        /// <returns>Lista de áreas de pátio</returns>
        /// <response code="200">Retorna a lista de áreas de pátio</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AreaPatioDto>>> GetAll()
        {
            try
            {
                var areas = await _areaPatioService.GetAllAreasPatioAsync();
                return Ok(areas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as áreas de pátio");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém uma área de pátio pelo seu ID
        /// </summary>
        /// <param name="id">ID da área de pátio</param>
        /// <returns>Dados da área de pátio</returns>
        /// <response code="200">Retorna a área de pátio solicitada</response>
        /// <response code="404">Área de pátio não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AreaPatioDto>> GetById(int id)
        {
            try
            {
                var area = await _areaPatioService.GetAreaPatioByIdAsync(id);
                if (area == null)
                    return NotFound($"Área de pátio com ID {id} não encontrada");

                return Ok(area);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter área de pátio com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém áreas por pátio
        /// </summary>
        /// <param name="idPatio">ID do pátio</param>
        /// <returns>Lista de áreas do pátio</returns>
        /// <response code="200">Retorna a lista de áreas do pátio</response>
        [HttpGet("patio/{idPatio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AreaPatioDto>>> GetByPatio(int idPatio)
        {
            try
            {
                var areas = await _areaPatioService.GetAreasByPatioAsync(idPatio);
                return Ok(areas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter áreas do pátio {idPatio}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Cadastra uma nova área de pátio
        /// </summary>
        /// <param name="areaPatioDto">Dados da área de pátio</param>
        /// <returns>Área de pátio cadastrada</returns>
        /// <response code="201">Área de pátio cadastrada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AreaPatioDto>> Create([FromBody] AreaPatioCreateDto areaPatioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novaArea = await _areaPatioService.CreateAreaPatioAsync(areaPatioDto);
                return CreatedAtAction(nameof(GetById), new { id = novaArea.IdAreaPatio }, novaArea);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar área de pátio");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Atualiza uma área de pátio existente
        /// </summary>
        /// <param name="id">ID da área de pátio</param>
        /// <param name="areaPatioDto">Dados atualizados da área de pátio</param>
        /// <returns>Área de pátio atualizada</returns>
        /// <response code="200">Área de pátio atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Área de pátio não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AreaPatioDto>> Update(int id, [FromBody] AreaPatioUpdateDto areaPatioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var areaAtualizada = await _areaPatioService.UpdateAreaPatioAsync(id, areaPatioDto);
                if (areaAtualizada == null)
                    return NotFound($"Área de pátio com ID {id} não encontrada");

                return Ok(areaAtualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar área de pátio com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Remove uma área de pátio
        /// </summary>
        /// <param name="id">ID da área de pátio</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Área de pátio removida com sucesso</response>
        /// <response code="404">Área de pátio não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _areaPatioService.DeleteAreaPatioAsync(id);
                if (!resultado)
                    return NotFound($"Área de pátio com ID {id} não encontrada");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir área de pátio com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }
    }
}
