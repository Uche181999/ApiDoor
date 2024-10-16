
using Api.Dtos.Account;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    [ApiController]
    [Route("/accounts")]
    public class AcountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IOrgRepo _orgRepo;
        private readonly IAuthorizationService _authorizationService;
        public AcountController(UserManager<AppUser> userManager,
         IOrgRepo orgRepo, ITokenService tokenService,
          SignInManager<AppUser> signInManager, IAuthorizationService authorizationService)

        {
            _userManager = userManager;
            _orgRepo = orgRepo;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
        }
        [HttpPost("/Register")]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("invalid input");
                }
                if (!await _orgRepo.OrgExistAsync(registerDto.OrganisationId))
                {
                    return BadRequest("organisation id does not exist");
                }
                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    OrganisationId = registerDto.OrganisationId,
                };
                var CreateUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (CreateUser.Succeeded)
                {
                    var roleresult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleresult.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(appUser);
                        var token = _tokenService.CreateToken(appUser, userRoles);

                        return Ok(new NewUserDto
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = token
                        });
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
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] SignInDto signInDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input ");
            }
            var User = await _userManager.Users.FirstOrDefaultAsync(c => c.UserName == signInDto.UserName);
            if (User == null)
            {
                return Unauthorized("username and/or password is incorrect");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(User, signInDto.Password!, false);
            if (!result.Succeeded)
            {
                return Unauthorized("username and/or password is incorrect");

            }

            var userRoles = await _userManager.GetRolesAsync(User);
            var token = _tokenService.CreateToken(User, userRoles);
            return Ok(new NewUserDto
            {
                UserName = User.UserName,
                Email = User.Email,
                Token = token
            });

        }
        [HttpPost("change_roles/{username}")]
        //[Authorize(Policy ="SpecialAdmin")]
        public async Task<IActionResult> AddAdminRole([FromRoute] string username)
        {
            var AuthorizationResult =await _authorizationService.AuthorizeAsync(User, username,"specialAdmin");
            var user = await _userManager.Users.FirstOrDefaultAsync(c => c.UserName == username);

            if (user == null)
            {
                return BadRequest("username does not exist");
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Admin");

            if (roleResult.Succeeded)
            {
                var userRole = await _userManager.GetRolesAsync(user);
                var token = _tokenService.CreateToken(user, userRole);
                
                return Ok(new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = token
                }
                );
            }
            else
            {
                return StatusCode(500, "something went wrong pls try again");
            }
        }

    }

}