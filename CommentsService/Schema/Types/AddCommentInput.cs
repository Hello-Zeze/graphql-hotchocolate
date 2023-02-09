namespace CommentsService.Schema.Types
{
    public record AddCommentInput(string Content, int CreatedBy, int PostId);
}
