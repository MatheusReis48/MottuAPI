using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MottuAPI.Application.DTOs.Moto;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.API.Controllers
{
    /// <summary>
    /// API para gerenciamento de motos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MotosController : ControllerBase
    {
        private readonly IMotoService _motoService;
        private readonly ILogger<MotosController> _logger;

        /// <summary>
        /// Construtor do controller de motos
        /// </summary>
        /// <param name="motoService">Serviço de motos</param>
        /// <param name="logger">Logger</param>
        public MotosController(IMotoService motoService, ILogger<MotosController> logger)
        {
            _motoService = motoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtém todas as motos cadastradas
        /// </summary>
        /// <returns>Lista de motos</returns>
        /// <response code="200">Retorna a lista de motos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MotoDto>>> GetAll()
        {
            try
            {
                var motos = await _motoService.GetAllMotosAsync();
                return Ok(motos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todas as motos");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém uma moto pelo seu ID
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>Dados da moto</returns>
        /// <response code="200">Retorna a moto solicitada</response>
        /// <response code="404">Moto não encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MotoDto>> GetById(int id)
        {
            try
            {
                var moto = await _motoService.GetMotoByIdAsync(id);
                if (moto == null)
                    return NotFound($"Moto com ID {id} não encontrada");

                return Ok(moto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter moto com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém motos por filial
        /// </summary>
        /// <param name="idFilial">ID da filial</param>
        /// <returns>Lista de motos da filial</returns>
        /// <response code="200">Retorna a lista de motos da filial</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("filial/{idFilial}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MotoDto>>> GetByFilial(int idFilial)
        {
            try
            {
                var motos = await _motoService.GetMotosByFilialAsync(idFilial);
                return Ok(motos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter motos da filial {idFilial}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém motos por status
        /// </summary>
        /// <param name="idStatus">ID do status</param>
        /// <returns>Lista de motos com o status especificado</returns>
        /// <response code="200">Retorna a lista de motos com o status</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("status/{idStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MotoDto>>> GetByStatus(int idStatus)
        {
            try
            {
                var motos = await _motoService.GetMotosByStatusAsync(idStatus);
                return Ok(motos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter motos com status {idStatus}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Obtém motos por pátio
        /// </summary>
        /// <param name="idPatio">ID do pátio</param>
        /// <returns>Lista de motos no pátio</returns>
        /// <response code="200">Retorna a lista de motos no pátio</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("patio/{idPatio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MotoDto>>> GetByPatio(int idPatio)
        {
            try
            {
                var motos = await _motoService.GetMotosByPatioAsync(idPatio);
                return Ok(motos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter motos do pátio {idPatio}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Cadastra uma nova moto
        /// </summary>
        /// <param name="motoDto">Dados da moto</param>
        /// <returns>Moto cadastrada</returns>
        /// <response code="201">Moto cadastrada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MotoDto>> Create([FromBody] MotoCreateDto motoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novaMoto = await _motoService.CreateMotoAsync(motoDto);
                return CreatedAtAction(nameof(GetById), new { id = novaMoto.IdMoto }, novaMoto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar moto");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Atualiza uma moto existente
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <param name="motoDto">Dados atualizados da moto</param>
        /// <returns>Moto atualizada</returns>
        /// <response code="200">Moto atualizada com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Moto não encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MotoDto>> Update(int id, [FromBody] MotoUpdateDto motoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var motoAtualizada = await _motoService.UpdateMotoAsync(id, motoDto);
                if (motoAtualizada == null)
                    return NotFound($"Moto com ID {id} não encontrada");

                return Ok(motoAtualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar moto com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }

        /// <summary>
        /// Remove uma moto
        /// </summary>
        /// <param name="id">ID da moto</param>
        /// <returns>Sem conteúdo</returns>
        /// <response code="204">Moto removida com sucesso</response>
        /// <response code="404">Moto não encontrada</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var resultado = await _motoService.DeleteMotoAsync(id);
                if (!resultado)
                    return NotFound($"Moto com ID {id} não encontrada");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao excluir moto com ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao processar sua solicitação");
            }
        }
    }
}
