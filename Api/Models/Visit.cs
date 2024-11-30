using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Visit

    {
        public Visit()
        {
            
        }

        public int Id { get; set; }
        public string? Visitor { get; set; }
        public string? Permission { get; set; }
        public int OrganisationId { get; set; }
        public int DoorId { get; set; }
        public DateTime EntryTime { get; set; } = DateTime.Now;
        public DateTime? ExitTime { get; set; }

    }
}