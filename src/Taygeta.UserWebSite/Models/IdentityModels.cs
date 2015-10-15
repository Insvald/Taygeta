// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Microsoft.AspNet.Identity.EntityFramework;

namespace Taygeta.UserWebSite.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
