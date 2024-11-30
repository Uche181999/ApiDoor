using Api.Dtos.Otp;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("Api/otp")]
    [ApiController]
    public class OtpController : ControllerBase
    {

        private readonly IOtpRepo _OtpRepo;
        public OtpController(IOtpRepo OtpRepo)
        {

            _OtpRepo = OtpRepo;


        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create()
        {

            var userOrg = int.Parse(User.FindFirst("OrganisationId")?.Value!);
            var userName = User.FindFirst("Given_Names")?.Value!;
            var email = User.FindFirst("Emails")?.Value!;
            //var otherEmail = User.FindFirstValue("email")!;
            //var name = User.Identity?.Name!;

            var rand = new Random();
            int code = rand.Next(100000, 999999);

           // Console.WriteLine($"username:  {userName}");
            //Console.WriteLine($"username:  {name}");
            //Console.WriteLine($"code:  {code}");
            //Console.WriteLine($"code:  {email}");
            //Console.WriteLine($"code:  {otherEmail}");
            //Console.WriteLine($"orgid:  {userOrg}");
            
            var createOtp = new CreateOtpDto(code, userName, userOrg);


            await _OtpRepo.CreateOtp(createOtp);

            return Ok(createOtp);
        }
        [HttpDelete]
        [Authorize]
        [Route("delete_all")]
        public async Task<IActionResult> Delete()
        {
            var otp = await _OtpRepo.DeleteOtp();
            if (otp == null)
            {
                return NotFound();
            }
            return Ok($"Successfully Deleted all record ");
        }
        
    }
}

