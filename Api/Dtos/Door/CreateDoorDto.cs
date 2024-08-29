using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Door
{
    public record class CreateDoorDto(string Name, int Code);
}