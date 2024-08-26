using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/doors")]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepo _doorRepo;
        public DoorController(IDoorRepo doorRepo)
        {
            _doorRepo = doorRepo;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doorModel = await _doorRepo.GetAllAsync();
            var doorDto = doorModel.Select(x => x.ToDoorDto());
            return Ok(doorDto);


        }
    }
}