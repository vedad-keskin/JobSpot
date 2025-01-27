using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class AspIdentityDbContext : IdentityDbContext
    {
        public AspIdentityDbContext(DbContextOptions<AspIdentityDbContext> options) : base(options) { }
    }
}
