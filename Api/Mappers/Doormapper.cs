using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Door;
using Api.Models;

namespace Api.Mappers
{
    public static class Doormapper
    {
        public static DoorDto ToDoorDto(this Door door)
        {
            return new DoorDto(door.Id, door.Name, door.Code, door.OrganisationId, door.Organisation?.ToOrgDto());
        }
        public static Door ToCreateDto(this CreateDoorDto door, int stockId)
        {
            return new Door
            {
                Name = door.Name,
                Code = door.Code,
                OrganisationId = stockId
            };
        }

    }
}