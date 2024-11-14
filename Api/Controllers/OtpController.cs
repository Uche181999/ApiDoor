using Api.Dtos.Otp;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/otp")]
    [ApiController]
    public class OtpController : ControllerBase
    {

        private readonly IOtpRepo _OtpRepo;
        public OtpController( IOtpRepo OtpRepo)
        {
            
            _OtpRepo = OtpRepo;
            

        }

        [HttpPost]

        public async Task<IActionResult> Create()
        {

            var userOrg = int.Parse(User.FindFirst("OrganisationId")?.Value!);
            var userName = User.Identity?.Name!;
            var   rand = new Random();
            int code = rand.Next(100000, 999999);

             Console.WriteLine("username: ", userName);
             Console.WriteLine("code: ", code);

             Console.WriteLine("orgid: ", userOrg);
            var createOtp = new CreateOtpDto(code, userName, userOrg);


            await _OtpRepo.CreateOtp(createOtp);

            return Ok(createOtp);
        }
    }
}
