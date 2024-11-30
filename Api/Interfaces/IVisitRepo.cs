using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interfaces
{
    public interface IVisitRepo

    {
        public Task<List<Visit>> GetAllAsync();
        public Task<Visit> CreateAsync(Visit visit);
        public Task<Visit?> AddExitasync(string userName, int orgId, int doorId);
        public Task<List<Visit>> GetAllAsync(int orgId);
        public Task<Visit?> GetByIdAsync(int id);
        public Task<Visit?> GetByIdAsync(int orgId, int id);
        public   Task<Visit?> DeleteAsync(int id);

    }
}