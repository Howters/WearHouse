using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WearHouse.Models
{
    public class User : IdentityUser
    {
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
