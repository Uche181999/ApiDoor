using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Org;
using Api.Models;

namespace Api.Interfaces
{
    public interface IOrgRepo
    {
        public Task<List<Organisation>> GetAllAsync();
        public Task<Organisation?> GetByIdAsync(int id);
        public Task<Organisation> CreateAsync(Organisation orgModel);
        public Task<Organisation?> UpdateAsync(int id, UpdateOrgDto updateModel);
        public Task<Organisation?> DeleteAsync(int id);
    }
}