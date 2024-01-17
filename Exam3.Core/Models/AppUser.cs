using Microsoft.AspNetCore.Identity;

namespace Exam3.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
