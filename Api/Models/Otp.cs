using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Otp
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Creator { get; set; } = "";
        public int OrganizationId { get; set; } 
        public Boolean IsUsed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}