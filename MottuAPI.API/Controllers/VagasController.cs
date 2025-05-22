using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MottuAPI.Application.DTOs.Vaga;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class VagasController : ControllerBase
    {
        private readonly IVagaService _vagaService;
        private readonly ILogger<VagasController> _logger;

        public VagasController(IVagaService vagaService, ILogger<VagasController> logger)
        {
            _vagaService = vagaService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todas as vagas cadastradas
        /// </summary>
        /// <returns>Lista de vagas</returns>
        /// <response code="200">Retorna a lista de vagas</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VagaDto>>> GetAll()
        {
            try
            {
                var vagas = await _vagaService.GetAllVagasAsync();
                return Ok(vagas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as vagas");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém uma vaga pelo seu ID
        /// </summary>
        /// <param name="id">ID da vaga</param>
        /// <returns>Dados da vaga</returns>
        /// <response code="200">Retorna a vaga solicitada</response>
        /// <response code="404">Vaga não encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VagaDto>> GetById(int id)
        {
            try
            {
                var vaga = await _vagaService.GetVagaByIdAsync(id);
                if (vaga == null)
                    return NotFound($"Vaga com ID {id} não encontrada");

                return Ok(vaga);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter vaga com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém vagas por área de pátio
        /// </summary>
        /// <param name="idAreaPatio">ID da área de pátio</param>
        /// <returns>Lista de vagas da área de pátio</returns>
        /// <response code="200">Retorna a lista de vagas da área de pátio</response>
        [HttpGet("area/{idAreaPatio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VagaDto>>> GetByAreaPatio(int idAreaPatio)
        {
            try
            {
                var vagas = await _vagaService.GetVagasByAreaPatioAsync(idAreaPatio);
                return Ok(vagas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter vagas da área de pátio {idAreaPatio}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém vagas por status
        /// </summary>
        /// <param name="status">Status da vaga (LIVRE, OCUPADA, BLOQUEADA, MANUTENCAO)</param>
        /// <returns>Lista de vagas com o status especificado</returns>
        /// <response code="200">Retorna a lista de vagas com o status</response>
        [HttpGet("status/{status}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VagaDto>>> GetByStatus(string status)
        {
            try
            {
                var vagas = await _vagaService.GetVagasByStatusAsync(status);
                return Ok(vagas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter vagas com status {status}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Cadastra uma nova vaga
        /// </summary>
        /// <param name="vagaDto">Dados da vaga</param>
        /// <returns>Vaga cadastrada</returns>
        /// <response code="201">Vaga cadastrada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VagaDto>> Create([FromBody] VagaCreateDto vagaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novaVaga = await _vagaService.CreateVagaAsync(vagaDto);
                return CreatedAtAction(nameof(GetById), new { id = novaVaga.IdVaga }, novaVaga);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar vaga");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Atualiza uma vaga existente
        /// </summary>
        /// <param name="id">ID da vaga</param>
        /// <param name="vagaDto">Dados atualizados da vaga</param>
        /// <returns>Vaga atualizada</returns>
        /// <response code="200">Vaga atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Vaga não encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VagaDto>> Update(int id, [FromBody] VagaUpdateDto vagaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var vagaAtualizada = await _vagaService.UpdateVagaAsync(id, vagaDto);
                if (vagaAtualizada == null)
                    return NotFound($"Vaga com ID {id} não encontrada");

                return Ok(vagaAtualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar vaga com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Remove uma vaga
        /// </summary>
        /// <param name="id">ID da vaga</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Vaga removida com sucesso</response>
        /// <response code="404">Vaga não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _vagaService.DeleteVagaAsync(id);
                if (!resultado)
                    return NotFound($"Vaga com ID {id} não encontrada");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir vaga com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }
    }
}
