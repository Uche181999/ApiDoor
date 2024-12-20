using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Organisation
    {
        public Organisation()
        {
        }

        public Organisation(string name, string emailDomain)
        {
            Name = name;
            EmailDomain = emailDomain;
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string EmailDomain { get; set; } = "";
        public List<Door> Doors { get; set; } = new List<Door>();
        public List<AppUser> AppUsers{ get; set; } = new List<AppUser>();


    }
}