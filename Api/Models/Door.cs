using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Door
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Code { get; set; }
        public int? OrgId { get; set; }
        public Organisation? Organisation{ get; set; }

    }
}