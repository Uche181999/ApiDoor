using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Door;
using Api.Models;

namespace Api.Interfaces
{
    public interface IDoorRepo
    {
        public Task<List<Door>> GetAllAsync();
        public Task<List<Door>> GetAllByOrdIdAsync(int id );
        public Task<Door?> GetDoorByIdAsync (int id);
        public Task<Door> CreateAsync(int orgId , CreateDoorDto doorDto);
        public Task<Door?> UpdateAsync(int id , UpdateDoorDto doorDto);
        public Task<Door?> DeleteAsync(int id);
    }
}