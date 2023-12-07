using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Gender? Gender { set; get; }
        public DateTime DateOfBirth { get; set; }
        public string UserImage { get; set; }
    }

}