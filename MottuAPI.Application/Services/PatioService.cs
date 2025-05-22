using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Patio;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.Application.Services
{
    public class PatioService : IPatioService
    {
        public async Task<IEnumerable<PatioDto>> GetAllPatiosAsync()
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<PatioDto> GetPatioByIdAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PatioDto>> GetPatiosByFilialAsync(int idFilial)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<PatioDto> CreatePatioAsync(PatioCreateDto patioDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<PatioDto> UpdatePatioAsync(int id, PatioUpdateDto patioDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePatioAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }
    }
}
