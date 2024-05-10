using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Visklineo.Database
{
    public partial class VisklineoDbContext : IdentityDbContext<ApplicationUser>
    {
        public VisklineoDbContext(DbContextOptions<VisklineoDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}