namespace BlogRazorPage.Models.Comment
{
    public class CreateCommentCommand
    {
        public string Text { get; set; }
        public long ProductId{ get; set; }
        public long UserId { get; set; }

    }

    public class DeleteCommentCommand
    {
        public long CommentId { get; set; }
    }

    public class EditCommentCommand
    {
        public string Text { get; set; }
        public long UserId { get; set; }
        public long CommentId { get; set; }
    }

    public class ChangeStatusCommentCommand
    {
        public long Id { get; set; }
        public CommentStatus status { get; set; }
    }

}
