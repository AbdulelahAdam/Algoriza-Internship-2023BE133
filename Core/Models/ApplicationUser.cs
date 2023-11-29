using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Specialization? Specialization { set; get; }
        public Gender? Gender { set; get; }
        public DateTime DateOfBirth { get; set; }
        public virtual byte[] UserImage { get; set; }
    }

}