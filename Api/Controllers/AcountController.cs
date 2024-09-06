using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Account;
using Api.Migrations;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Api.Controllers
{

    [ApiController]
    [Route("/accounts")]
    public class AcountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AcountController(UserManager<AppUser> userManager)

        {
            _userManager = userManager;

        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("invalid input");
                }
                var appuser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    OrganisationId = registerDto.OrganisationId,
                };
                var CreateUser = await _userManager.CreateAsync(appuser, registerDto.Password);

                if (CreateUser.Succeeded)
                {
                    var roleresult = await _userManager.AddToRoleAsync(appuser, "User");
                    if (roleresult.Succeeded)
                    {
                        return Ok("User created");
                    }
                    else
                    {
                        return StatusCode(500, roleresult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, CreateUser.Errors);
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }

        }
    }
}