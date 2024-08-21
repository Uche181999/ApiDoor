using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repos
{
    public class OrgRepo : IOrgRepo
    {
        private readonly AppDbContext _Context;
        public OrgRepo(AppDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Organisation>> GetAllAsync()
        {
            return await _Context.Organisations.ToListAsync();

        }
    }
}