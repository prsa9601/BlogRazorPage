namespace BlogRazorPage.Models.Category;

public class EditCategoryCommand
{

    public long Id { get; set; }
    public string Title { get; set; }
    public string MetaTag { get; set; }
    public string MetaDescription { get; set; }
    public string Slug { get; set; }
}