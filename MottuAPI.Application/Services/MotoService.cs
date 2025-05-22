using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MottuAPI.Application.DTOs.Moto;
using MottuAPI.Application.Interfaces;

namespace MottuAPI.Application.Services
{
    public class MotoService : IMotoService
    {
        public async Task<IEnumerable<MotoDto>> GetAllMotosAsync()
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<MotoDto> GetMotoByIdAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MotoDto>> GetMotosByFilialAsync(int idFilial)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MotoDto>> GetMotosByStatusAsync(int idStatus)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MotoDto>> GetMotosByPatioAsync(int idPatio)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<MotoDto> CreateMotoAsync(MotoCreateDto motoDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<MotoDto> UpdateMotoAsync(int id, MotoUpdateDto motoDto)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMotoAsync(int id)
        {
            // Implementação será feita quando integrarmos com o banco de dados
            throw new NotImplementedException();
        }
    }
}
