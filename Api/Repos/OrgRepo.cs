using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Dtos.Org;
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

        public async Task<Organisation> CreateAsync(Organisation orgModel)
        {
            await _Context.Organisations.AddAsync(orgModel);
            await _Context.SaveChangesAsync();
            return orgModel;
        }

        public async  Task<Organisation?> DeleteAsync(int id)
        {
            var orgModel = await _Context.Organisations.FirstOrDefaultAsync(s => s.Id == id);
            if (orgModel == null)
            {
                return null;
            }
            _Context.Organisations.Remove(orgModel);
            await _Context.SaveChangesAsync();
            return orgModel;
        }

        public async Task<List<Organisation>> GetAllAsync()
        {
            return await _Context.Organisations.ToListAsync();


        }

        public async Task<Organisation?> GetByIdAsync(int id)
        {
            var OrgModel = await _Context.Organisations.FirstOrDefaultAsync(x => x.Id == id);
            if (OrgModel == null)
            {
                return null;
            }
            return OrgModel;


        }

        public async Task<Organisation?> UpdateAsync(int id, UpdateOrgDto updateModel)
        {
            var existOrg = await _Context.Organisations.FirstOrDefaultAsync(x => x.Id == id);
            if (existOrg == null)
            {
                return null;
            }

            existOrg.Name = updateModel.Name ?? existOrg.Name;
            existOrg.EmailDomain = updateModel.EmailDomain ?? existOrg.EmailDomain;

            await _Context.SaveChangesAsync();
            return existOrg;
        }
    }
}