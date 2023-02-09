using PostsService.Data;

namespace PostsService.Schema
{
    public class Query
    {
        public List<Post> GetPostsByAuthorId(int authorId, [Service] ApplicationDbContext context)
        {
            return context.Posts
                            .Where(p => p.CreatedBy== authorId)
                            .ToList();
        }

        public Post GetPost(int id, [Service] ApplicationDbContext context)
        {
            return context.Posts
                            .Where(p => p.Id == id)
                            .FirstOrDefault();
        }
    }
}
