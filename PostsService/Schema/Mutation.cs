using PostsService.Data;
using PostsService.Schema.Types;

namespace PostsService.Schema
{
    public class Mutation
    {
        public async Task<AddPostPayload> AddPostAsync(AddPostInput input, [Service] ApplicationDbContext context)
        {
            var post = new Post
            {
                Content = input.Content,
                CreatedBy = input.CreatedBy,
                CreatedOn = DateTime.UtcNow,
            };

            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return new AddPostPayload(post);
        }
    }
}
