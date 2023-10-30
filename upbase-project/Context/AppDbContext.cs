using Microsoft.EntityFrameworkCore;

namespace upbase_project.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
