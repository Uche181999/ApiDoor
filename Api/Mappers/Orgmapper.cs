using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Org;
using Api.Models;

namespace Api.Mappers
{
    public static class Orgmapper
    {
        public static OrgDto ToOrgDto(this Organisation OrgModel){
            return new OrgDto(
                OrgModel.Id,
                OrgModel.Name,
                OrgModel.EmailDomain
            );
        }
         public static Organisation ToOrgDto(this CreateOrgDto OrgModel){
            return new Organisation(
                OrgModel.Name,
                OrgModel.EmailDomain
            );
        }
    }
}