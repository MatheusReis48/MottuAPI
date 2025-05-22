using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Moto;

namespace MottuAPI.Application.Interfaces
{
    public interface IMotoService
    {
        Task<IEnumerable<MotoDto>> GetAllMotosAsync();
        Task<MotoDto> GetMotoByIdAsync(int id);
        Task<IEnumerable<MotoDto>> GetMotosByFilialAsync(int idFilial);
        Task<IEnumerable<MotoDto>> GetMotosByStatusAsync(int idStatus);
        Task<IEnumerable<MotoDto>> GetMotosByPatioAsync(int idPatio);
        Task<MotoDto> CreateMotoAsync(MotoCreateDto motoDto);
        Task<MotoDto> UpdateMotoAsync(int id, MotoUpdateDto motoDto);
        Task<bool> DeleteMotoAsync(int id);
    }
}
