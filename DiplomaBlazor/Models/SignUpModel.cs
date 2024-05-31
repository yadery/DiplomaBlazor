using System.ComponentModel.DataAnnotations;

namespace DiplomaBlazor.Models
{
    public class SignUpModel
    {
        [Required, MaxLength(30)]
        public string  Name { get; set; }
        [Required, MaxLength(20)]
        public string Username { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
    }
}
