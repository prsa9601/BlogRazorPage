using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogRazorPage.Areas.Admin.Models
{
    public class ckeditorViewModel
    {
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }

    }
}
