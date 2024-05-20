using BlogRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Infrastructure.RazorUtils;

public class BaseRazorFilter<TFilterParam> : BaseRazorPage where TFilterParam : BaseFilterParam
{
    [BindProperty(SupportsGet = true)]
    public TFilterParam FilterParams { get; set; }
}