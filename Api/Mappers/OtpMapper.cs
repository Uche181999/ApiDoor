using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Otp;
using Api.Models;

namespace Api.Mappers
{
    public static class OtpMapper
    {
        public static Otp ToCreateDto(this CreateOtpDto otp)
        {
            return new Otp
            {
                Code = otp.Code,
                Creator = otp.Creator,
                OrganizationId = otp.OrganizationId
            };
        }
    }
}