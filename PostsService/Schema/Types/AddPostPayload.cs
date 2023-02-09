using PostsService.Data;

namespace PostsService.Schema.Types
{
    public class AddPostPayload
    {
        public Post Post { get; }

        public AddPostPayload(Post post)
        {
            Post = post;
        }
    }
}
