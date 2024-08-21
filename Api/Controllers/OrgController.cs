using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Mappers;
using Api.Interfaces;


namespace Api.Controllers
{
    [Route("organisations")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        private readonly IOrgRepo _OrgRepo;
        public OrgController(IOrgRepo OrgRepo)
        {
            _OrgRepo = OrgRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orgModel = await _OrgRepo.GetAllAsync();
            var orgDto = orgModel.Select(s => s.ToOrgDto());

            return Ok(orgDto);

        }

    }
}