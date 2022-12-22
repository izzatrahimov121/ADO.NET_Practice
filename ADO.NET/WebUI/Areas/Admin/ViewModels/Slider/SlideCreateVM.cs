using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.ViewModels.Slider
{
    public class SlideCreateVM
    {
        [Required, MaxLength(200)]
        public string Offer { get; set; }
        [Required, MaxLength(200)]
        public IFormFile?  Photo { get; set; }
        [Required, MaxLength(200)]
        public string Description { get; set; }
    }
}
