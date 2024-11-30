using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interfaces;
using Api.Migrations;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repos
{
    public class VisitRepo : IVisitRepo

    {
        private readonly AppDbContext _context;
        public VisitRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Visit?> AddExitasync(string userName, int orgId, int doorId)
        {

            var visit = await _context.Visits.Where(c => c.Visitor == userName
                        && c.OrganisationId == orgId && c.DoorId == doorId && c.ExitTime == null)
                        .OrderByDescending(c => c.EntryTime).FirstOrDefaultAsync();
            if (visit == null)
            {
                return null;
            }
            visit.ExitTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return visit;

        }


        public async Task<Visit> CreateAsync(Visit visit)
        {

            await _context.Visits.AddAsync(visit);
            await _context.SaveChangesAsync();
            return visit;
        }
        public async Task<List<Visit>> GetAllAsync()
        {
            return await _context.Visits.ToListAsync();


        }
        public async Task<List<Visit>> GetAllAsync(int orgId)
        {
            return await _context.Visits.Where(c => c.OrganisationId == orgId ).ToListAsync();


        }
         public async Task<Visit?> GetByIdAsync(int id)
        {
            var visitModel = await _context.Visits.FirstOrDefaultAsync(x => x.Id == id);
            if (visitModel == null)
            {
                return null;
            }
            return visitModel;


        }
         public async Task<Visit?> GetByIdAsync(int orgId,int id)
        {
            var visitModel = await _context.Visits.FirstOrDefaultAsync(x => x.Id == id && x.OrganisationId == orgId);
            if (visitModel == null)
            {
                return null;
            }
            return visitModel;


        }
         public async  Task<Visit?> DeleteAsync(int id)
        {
            var visitModel = await _context.Visits.FirstOrDefaultAsync(x=> x.Id == id);
            if (visitModel == null){
                return null;
            }
            _context.Visits.Remove(visitModel);
            await _context.SaveChangesAsync();
            return visitModel;


        }
    }
}