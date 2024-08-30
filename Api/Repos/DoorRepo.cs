using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Dtos.Door;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Repos
{
    public class DoorRepo : IDoorRepo
    {
        private readonly AppDbContext _context;

        public DoorRepo(AppDbContext context)
        {
            _context = context;
           
        }

        public async Task<Door> CreateAsync(int orgId, CreateDoorDto doorDto)
        {
            var createModel = doorDto.ToCreateDto(orgId);
            await _context.Doors.AddAsync(createModel);
            await _context.SaveChangesAsync();
            return createModel;

        }

        public async  Task<Door?> DeleteAsync(int id)
        {
            var doorModel = await _context.Doors.FirstOrDefaultAsync(x=> x.Id == id);
            if (doorModel == null){
                return null;
            }
            _context.Doors.Remove(doorModel);
            await _context.SaveChangesAsync();
            return doorModel;


        }

        public async Task<List<Door>> GetAllAsync()
        {
            return await _context.Doors.Include(x => x.Organisation).ToListAsync();
        }

        public async  Task<List<Door>> GetAllByOrdIdAsync(int id)
        {
            var Door = await  _context.Doors.Include(x => x.Organisation).Where(x => x.OrganisationId == id).ToListAsync();
            return Door;

        }

        public async Task<Door?> GetDoorByIdAsync ( int id)
        {
         var doorModel = await _context.Doors.Include(x => x.Organisation).FirstOrDefaultAsync(x => x.Id == id);
         if (doorModel == null){
            return null;
         }
         
         return doorModel;
        }

        public async  Task<Door?> UpdateAsync( int id, UpdateDoorDto doorDto)
        {
            var existDoor = await _context.Doors.FirstOrDefaultAsync(x => x.Id == id);
            if (existDoor == null){
                return null ;
            }
            existDoor.Name = doorDto.Name ?? existDoor.Name ;
            existDoor.Code = doorDto.Code ?? existDoor.Code ;
            existDoor.OrganisationId = doorDto.OrganisationId ?? existDoor.OrganisationId;
            await _context.SaveChangesAsync();
            return existDoor;


        }
    }
}

