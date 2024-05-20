namespace BlogRazorPage.Models.Post
{
    public class CreatePostCommand
    {
    
        public long UserId { get; set; }
        public IFormFile ImageFile { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string MetaDescription { get; set; }

    }
    public class AddImageCommand
    {
        public IFormFile ImageFile { get; set; }
        public long PostId { get; set; }
        //public int Sequence { get; set; }
    }
    public record class DeletePostCommand(long postId);

    public class EditPostCommand
    {
     
        public long Id { get; set; }
        public IFormFile ImageFile { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }

    }

    public record ShowPostCommand(long postId);

}
