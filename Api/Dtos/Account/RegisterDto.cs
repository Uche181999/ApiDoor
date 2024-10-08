using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Dtos.Account
{
    public record class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
       public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; } ="";
        [Required]
        public int OrganisationId { get; set; }
    }

}