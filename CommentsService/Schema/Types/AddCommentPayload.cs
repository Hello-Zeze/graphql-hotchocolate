using CommentsService.Data;

namespace CommentsService.Schema.Types
{
    public class AddCommentPayload
    {
        public Comment Comment { get; }

        public AddCommentPayload(Comment comment)
        {
            Comment = comment;
        }
    }
}
