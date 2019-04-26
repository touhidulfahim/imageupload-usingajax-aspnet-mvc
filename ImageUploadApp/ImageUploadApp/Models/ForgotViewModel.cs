using System.ComponentModel.DataAnnotations;

namespace ImageUploadApp.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}