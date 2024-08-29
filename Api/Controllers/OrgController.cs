using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Mappers;
using Api.Interfaces;
using Api.Dtos.Org;


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
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var orgModel = await _OrgRepo.GetByIdAsync(id);
            if (orgModel == null)
            {
                return NotFound();
            }
            return Ok(orgModel.ToOrgDto());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrgDto createModel)
        {
            var orgModel = createModel.ToCreateOrgDto();
            await _OrgRepo.CreateAsync(orgModel);
            return CreatedAtAction(nameof(GetById), new { id = orgModel.Id }, orgModel.ToOrgDto());

        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrgDto updateModel)
        {
            if (updateModel == null)
            {
                return BadRequest("You did not fill the required field");
            }
            var orgModel = await _OrgRepo.UpdateAsync(id, updateModel);
            if (orgModel == null)
            {
                return NotFound();
            }
            return Ok(orgModel.ToOrgDto());

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var orgModel = await _OrgRepo.DeleteAsync(id);
            if (orgModel == null)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}