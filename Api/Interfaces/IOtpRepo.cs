using System;
using Api.Dtos.Otp;
using Api.Models;

namespace Api.Interfaces;

public interface IOtpRepo
{
 public  Task<Otp?> CreateOtp(CreateOtpDto Otp);
 public  Task<string> DeleteOtp();
 public  Task<Otp?> OtpIsValid(int? otp);
}
