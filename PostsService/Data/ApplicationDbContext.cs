using Microsoft.EntityFrameworkCore;

namespace PostsService.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
