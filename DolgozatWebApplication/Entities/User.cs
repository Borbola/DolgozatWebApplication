using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DolgozatWebApplication.Entities
{
    public class User : IdentityUser
    {
        public string felhasznalonev { get; set; }
        public string Email { get; set; }
        public string Jelszo { get; set; }
    }
}
