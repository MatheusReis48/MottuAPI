using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Vaga;

namespace MottuAPI.Application.Interfaces
{
    public interface IVagaService
    {
        Task<IEnumerable<VagaDto>> GetAllVagasAsync();
        Task<VagaDto> GetVagaByIdAsync(int id);
        Task<IEnumerable<VagaDto>> GetVagasByAreaPatioAsync(int idAreaPatio);
        Task<IEnumerable<VagaDto>> GetVagasByStatusAsync(string status);
        Task<VagaDto> CreateVagaAsync(VagaCreateDto vagaDto);
        Task<VagaDto> UpdateVagaAsync(int id, VagaUpdateDto vagaDto);
        Task<bool> DeleteVagaAsync(int id);
    }
}
