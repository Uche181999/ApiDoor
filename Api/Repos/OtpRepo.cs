using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Dtos.Otp;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<string> DeleteOtp()
        {
            var allRecords = await _context.Otps.ToListAsync();
            _context.Otps.RemoveRange(allRecords);

            await _context.SaveChangesAsync();
            return "successful";
        }

        public async Task<Otp?> OtpIsValid(int? otp)
        {
            var existOtp = await  _context.Otps.FirstOrDefaultAsync(o => o.Code == otp);
            if (existOtp == null){
                return null;
            }
            TimeSpan difference =  DateTime.Now - existOtp.CreatedAt  ;

            if (!existOtp.IsUsed && difference.TotalMinutes <= 30){
                existOtp.IsUsed = true; 
                return existOtp; 
            }
            else {
                return null;
            }
        }
    }
}