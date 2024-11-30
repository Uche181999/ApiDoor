using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Door;
using Api.Dtos.Otp;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
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
        private readonly IOtpRepo _otpRepo;
        private readonly IAuthorizationService _authorizationService;
        private readonly IVisitRepo _visitRepo;
        public DoorController(IDoorRepo doorRepo, IOrgRepo orgRepo, IOtpRepo otpRepo, IAuthorizationService authorizationService, IVisitRepo visitRepo)
        {
            _doorRepo = doorRepo;
            _orgRepo = orgRepo;
            _otpRepo = otpRepo;
            _authorizationService = authorizationService;
            _visitRepo = visitRepo;

        }
        [HttpGet]
        [Route("/organisations/doors")]
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
        /* [HttpGet]
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

         }*/

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
            return Ok($"successfuly deleted the the record of id {id}");

        }
        [HttpGet]
        [Route("organisations/{orgId}/doors/{id}")]
        public async Task<IActionResult> GetDoorById([FromRoute] int orgId, [FromRoute] int id, [FromQuery] int? otp)
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
            if (otp == null)
            {
                var AuthorizationResult = await _authorizationService.AuthorizeAsync(User, doorModel, "GroupAdmin");
                if (!AuthorizationResult.Succeeded)
                {
                    return Forbid("Authorization failed.");

                }
                var userOrg = int.Parse(User.FindFirst("OrganisationId")?.Value!);
                var userName = User.FindFirst("Given_Names")?.Value!;
                var visit = new Visit{
                    Visitor = userName,
                    Permission = userName,
                    OrganisationId =orgId,
                    DoorId =id,
                };
                await _visitRepo.CreateAsync(visit);

            }
            else
            {
                var validOtp = await _otpRepo.OtpIsValid(otp);
                if (validOtp == null)
                {
                    return BadRequest(" Invalid token.  Please request token from an Admin");
                }

                var AuthorizationResult = await _authorizationService.AuthorizeAsync(User, validOtp, "OtpAccess");
                if (!AuthorizationResult.Succeeded)
                {
                    return Forbid("Authorization failed.");
                }
                var userOrg = int.Parse(User.FindFirst("OrganisationId")?.Value!);
                var userName = User.FindFirst("Given_Names")?.Value!;
                var visit = new Visit{
                    Visitor = userName,
                    Permission = validOtp.Creator,
                    OrganisationId = validOtp.OrganizationId,
                    DoorId =id,
                };;
                await _visitRepo.CreateAsync(visit);
                Console.WriteLine(validOtp);

            }
            return Ok(doorModel.ToDoorDto());

        }
        [HttpPost]
        [Route("exit/organisations/{orgId}/doors/{id}")]
        public async Task<IActionResult> Revoke([FromRoute] int orgId, [FromRoute] int id)
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



            var userName = User.FindFirst("Given_Names")?.Value!;
            var visit =await  _visitRepo.AddExitasync(userName, orgId, id);
            if (visit == null)
            {
              return BadRequest(" you have not visited before");  
            }

            return Ok($"{visit.Visitor} was successfully logged out of door {visit.DoorId} in organisation of id {visit.OrganisationId}");

        }


    }





}