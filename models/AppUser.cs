using Microsoft.AspNetCore.Identity;

namespace csahrpstock.models
{
    public class AppUser: IdentityUser
    {
        public List<Portfolio> Portfolio {get; set;} = new List<Portfolio>();
    }
}