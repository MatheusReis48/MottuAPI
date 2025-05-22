using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Vaga;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.Application.Services
{
    public class VagaService : IVagaService
    {
        public async Task<IEnumerable<VagaDto>> GetAllVagasAsync()
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<VagaDto> GetVagaByIdAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VagaDto>> GetVagasByAreaPatioAsync(int idAreaPatio)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VagaDto>> GetVagasByStatusAsync(string status)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<VagaDto> CreateVagaAsync(VagaCreateDto vagaDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<VagaDto> UpdateVagaAsync(int id, VagaUpdateDto vagaDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteVagaAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }
    }
}
