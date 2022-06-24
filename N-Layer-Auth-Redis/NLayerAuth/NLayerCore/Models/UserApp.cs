using Microsoft.AspNetCore.Identity;


namespace NLayerCore.Models
{
    public class UserApp : IdentityUser
    {
        public string? City { get; set; }
    }
}
