using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.AreaPatio;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.Application.Services
{
    public class AreaPatioService : IAreaPatioService
    {
        public async Task<IEnumerable<AreaPatioDto>> GetAllAreasPatioAsync()
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<AreaPatioDto> GetAreaPatioByIdAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AreaPatioDto>> GetAreasByPatioAsync(int idPatio)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<AreaPatioDto> CreateAreaPatioAsync(AreaPatioCreateDto areaPatioDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<AreaPatioDto> UpdateAreaPatioAsync(int id, AreaPatioUpdateDto areaPatioDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAreaPatioAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }
    }
}
