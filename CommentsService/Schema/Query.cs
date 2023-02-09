using CommentsService.Data;

namespace CommentsService.Schema
{
    public class Query
    {
        public List<Comment> GetCommentsByAuthorId(int authorId, [Service]ApplicationDbContext context)
        {
            return context.Comments
                            .Where(c => c.CreatedBy== authorId)
                            .ToList();
        }

        public List<Comment> GetCommentsByPostId(int postId, [Service]ApplicationDbContext context)
        {
            return context.Comments
                            .Where(c => c.PostId == postId)
                            .ToList();
        }
    }
}
