using Microsoft.EntityFrameworkCore;

namespace CommentsService.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
