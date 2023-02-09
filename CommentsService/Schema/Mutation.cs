using CommentsService.Data;
using CommentsService.Schema.Types;

namespace CommentsService.Schema
{
    public class Mutation
    {
        public async Task<AddCommentPayload> AddCommentAsync(AddCommentInput input, [Service] ApplicationDbContext context)
        {
            var comment = new Comment
            {
                Content = input.Content,
                CreatedBy = input.CreatedBy,
                PostId= input.PostId,
                CreatedOn = DateTime.UtcNow,
            };

            context.Comments.Add(comment);
            await context.SaveChangesAsync();

            return new AddCommentPayload(comment);
        }
    }
}
