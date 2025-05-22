using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Patio;

namespace MottuAPI.Application.Interfaces
{
    public interface IPatioService
    {
        Task<IEnumerable<PatioDto>> GetAllPatiosAsync();
        Task<PatioDto> GetPatioByIdAsync(int id);
        Task<IEnumerable<PatioDto>> GetPatiosByFilialAsync(int idFilial);
        Task<PatioDto> CreatePatioAsync(PatioCreateDto patioDto);
        Task<PatioDto> UpdatePatioAsync(int id, PatioUpdateDto patioDto);
        Task<bool> DeletePatioAsync(int id);
    }
}
