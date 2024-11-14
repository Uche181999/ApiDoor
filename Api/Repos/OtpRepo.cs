using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Dtos.Otp;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;

namespace Api.Repos
{
    public class OtpRepo : IOtpRepo
    {
        private readonly AppDbContext _context;
        public OtpRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Otp?> CreateOtp(CreateOtpDto otpDto)
        {
            var createModel = otpDto.ToCreateDto();
            await _context.Otps.AddAsync(createModel);
            await _context.SaveChangesAsync();
            return createModel;
        }
    }
}