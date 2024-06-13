using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Models
{
    internal class SignInModel
    {
        [Required(ErrorMessage = "Введите корректные значения"), MaxLength(20)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Введите корректные значения"), MaxLength(20)]
        public string Password { get; set; }
    }
}
