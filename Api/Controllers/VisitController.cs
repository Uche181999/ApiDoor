using Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/visit")]
    [ApiController]
    public class VisitController : ControllerBase
    {



        private readonly IVisitRepo _visitRepo;
        private readonly IOrgRepo _orgRepo;
        public VisitController(IVisitRepo visitRepo, IOrgRepo orgRepo)
        {

            _visitRepo = visitRepo;
            _orgRepo = orgRepo;


        }
        [HttpGet]
        [Authorize(Policy = "GlobalAdmin")]
        public async Task<IActionResult> getAll()
        {
            var visitModel = await _visitRepo.GetAllAsync();

            return Ok(visitModel);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = "GlobalAdmin")]
        public async Task<IActionResult> getAllOne( int id)
        {
            var visitModel = await _visitRepo.GetByIdAsync(id);
            if (visitModel == null)
            {
                return NotFound();
            }
        
            return Ok(visitModel);
        }


        [HttpGet]
        [Route("/api/{orgId}/visit")]
        [Authorize(Policy = "SpecialAdmin")]
        public async Task<IActionResult> getAll([FromRoute] int orgId)
        {
            var visitModel = await _visitRepo.GetAllAsync(orgId);

            return Ok(visitModel);
        }
        [HttpGet]
        [Route("/api/{orgId}/visit/{id}")]
        [Authorize(Policy = "SpecialAdmin")]
        public async Task<IActionResult> getById([FromRoute] int orgId,[FromRoute] int id )
        {
            var visitModel = await _visitRepo.GetByIdAsync(orgId ,id);
            if (visitModel == null)
            {
                return NotFound();
            }
        
            return Ok(visitModel);
        }


        [HttpDelete]
        [Route("/api/{orgId}/visit/{id}")]
        [Authorize(Policy = "SpecialAdmin")]
        public async Task<IActionResult> Delete([FromRoute] int orgId,[FromRoute] int id )
        {
            if (!await _orgRepo.OrgExistAsync(orgId))
            {
                return BadRequest("organisation id does not exist");

            }
            var visitModel = await _visitRepo.DeleteAsync(id);
            if (visitModel == null)
            {
                return NotFound();
            }
            return Ok($"successfuly deleted the the record of id {id}");
        }
    }
}


