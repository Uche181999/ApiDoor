using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string EmailDomain { get; set; } = "";
        public List<Door> Doors { get; set; } = new List<Door>();


    }
}