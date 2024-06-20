using System.ComponentModel.DataAnnotations;

namespace DiplomaBlazor.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Введите корректные значения"), MaxLength(30)]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Введите корректные значения"), MaxLength(20)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Введите корректные значения"), MinLength(8)]
        public string Password { get; set; }
    }
}
