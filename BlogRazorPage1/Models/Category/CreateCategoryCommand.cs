namespace BlogRazorPage.Models.Category
{
    public class CreateCategoryCommand
    {
 
        public string Title { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
    }

    public class DeleteCategoryCommand
    {
        public DeleteCategoryCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set;}
    }
}
