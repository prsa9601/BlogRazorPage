namespace BlogRazorPage.Models.Comment
{
    public class CommentDto : BaseDto
    {

        public long UserId { get; set; }
        public long PostId { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }

    }
    public enum CommentStatus
    {
        Pending,
        Accepted,
        Rejected
    }
    public class CommentFilterData : BaseDto
    {
        public long UserId { get; set; }
        public long PostId { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class CommentFilterParam : BaseFilterParam
    {
        public long? UserId { get; set; }
        public long? PostId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CommentStatus? CommentStatus { get; set; }
        public OrderBy? OrderBy { get; set; }

    }
    public class CommentFilterDataProduct : BaseDto
    {
        public long UserId { get; set; }
        public string userAvatar { get; set; }
        public string UserName { get; set; }
        public long PostId { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }
    }
    public class CommentFilterParamProduct : BaseFilterParam
    {
        public long? UserId { get; set; }
        public long? PostId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CommentStatus? CommentStatus { get; set; }
        public OrderBy? OrderBy { get; set; }

    }
    public enum OrderBy
    {
        Latest,
    }
    public class CommentFilterResult : BaseFilter<CommentFilterData, CommentFilterParam>
    {

    }
    public class CommentFilterResultProduct : BaseFilter<CommentFilterDataProduct, CommentFilterParamProduct>
    {

    }
}
