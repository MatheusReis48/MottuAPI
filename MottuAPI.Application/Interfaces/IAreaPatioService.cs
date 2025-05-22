using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.AreaPatio;

namespace MottuAPI.Application.Interfaces
{
    public interface IAreaPatioService
    {
        Task<IEnumerable<AreaPatioDto>> GetAllAreasPatioAsync();
        Task<AreaPatioDto> GetAreaPatioByIdAsync(int id);
        Task<IEnumerable<AreaPatioDto>> GetAreasByPatioAsync(int idPatio);
        Task<AreaPatioDto> CreateAreaPatioAsync(AreaPatioCreateDto areaPatioDto);
        Task<AreaPatioDto> UpdateAreaPatioAsync(int id, AreaPatioUpdateDto areaPatioDto);
        Task<bool> DeleteAreaPatioAsync(int id);
    }
}
