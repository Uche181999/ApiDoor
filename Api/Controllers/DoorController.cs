using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Door;
using Api.Interfaces;
using Api.Mappers;
using Api.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("")]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepo _doorRepo;
        private readonly IOrgRepo _orgRepo;
        public DoorController(IDoorRepo doorRepo, IOrgRepo orgRepo)
        {
            _doorRepo = doorRepo;
            _orgRepo = orgRepo;

        }
        [HttpGet]
        [Route("/doors")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var doorModel = await _doorRepo.GetAllAsync();
            var doorDto = doorModel.Select(x => x.ToDoorDto());
            return Ok(doorDto);
        }
        [HttpGet]
        [Route("/organisations/{orgId}/doors")]
        public async Task<IActionResult> GetAllDoorsByOrgId([FromRoute] int orgId)
        {
            if (!await _orgRepo.OrgExistAsync(orgId))
            {
                return BadRequest("organisation id does not exist");
            }

            var doorModels = await _doorRepo.GetAllByOrdIdAsync(orgId);
            var doorsDto = doorModels.Select(x => x.ToDoorDto());
            return Ok(doorsDto);
        }
        [HttpGet]
        [Route("/organisations/{orgId}/doors/{id}")]
        public async Task<IActionResult> GetDoorById([FromRoute] int orgId, [FromRoute] int id)
        {
            if (!await _orgRepo.OrgExistAsync(orgId))
            {
                return BadRequest("organisation id does not exist");
            }
            var doorModel = await _doorRepo.GetDoorByIdAsync(id);
            if (doorModel == null)
            {
                return NotFound();
            }
            return Ok(doorModel.ToDoorDto());

        }

        [HttpPost]
        [Route("/organisations/{orgId}/doors")]
        public async Task<IActionResult> Create([FromRoute] int orgId, [FromBody] CreateDoorDto doorDto)
        {

            if (!await _orgRepo.OrgExistAsync(orgId))
            {
                return BadRequest("organisation id does not exist");

            }
            var createModel = await _doorRepo.CreateAsync(orgId, doorDto);
            var createdDoor = await _doorRepo.GetDoorByIdAsync(createModel.Id);

            if (createdDoor == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetDoorById), new { orgId = createdDoor.OrganisationId, id = createdDoor.Id }, createdDoor.ToDoorDto());
        }
        [HttpPatch]
        [Route("/organisations/{orgId}/doors/{id}")]
        public async Task<IActionResult> Update([FromRoute] int orgId, [FromRoute] int id, [FromBody] UpdateDoorDto updateDoor)
        {
            if (!await _orgRepo.OrgExistAsync(orgId))
            {
                return BadRequest("organisation id does not exist");

            }
            var updateModel = await _doorRepo.UpdateAsync(id, updateDoor);
            if (updateModel == null)
            {
                return NotFound();
            }
            var updatedDoor = await _doorRepo.GetDoorByIdAsync(updateModel.Id);
            if (updatedDoor == null)
            {
                return NotFound();
            }
            return Ok(updatedDoor.ToDoorDto());
        }
        [HttpDelete]
        [Route("/organisations/{orgId}/doors/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromRoute] int orgId)
        {
            if (!await _orgRepo.OrgExistAsync(orgId))
            {
                return BadRequest("organisation id does not exist");

            }
            var doorModel = await _doorRepo.DeleteAsync(id);
            if (doorModel == null)
            {
                return NotFound();
            }
            return NoContent();

        }

    }
}