using Microsoft.AspNetCore.Identity;

namespace Assets.Domain.Entities
{
     public class User: IdentityUser
    {
        public DateOnly DateOfBirth {  get; set; }  
        public string? Nationality { get; set; }     
    }
}
