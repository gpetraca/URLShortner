using Microsoft.AspNet.Identity.EntityFramework;

namespace UrlShortner.Models
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("UrlContext")
        {
        }
    }
}