using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Org;
using Api.Models;

namespace Api.Dtos.Door
{
    public record class DoorDto(int Id, string Name, int Code, int? OrganisationId, OrgDto? Organisation);

}