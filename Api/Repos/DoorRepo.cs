using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interfaces;
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

        public async Task<List<Door>> GetAllAsync()
        {
            return await _context.Doors.Include(x => x.Organisation).ToListAsync();
        }
    }
}