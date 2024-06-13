using SQLite;
using System.ComponentModel.DataAnnotations;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;

namespace DiplomaBlazor.Data
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
  
        public int TripId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите корректное значение"), MaxLength(100)]
        public string For { get; set; }

        [Range(0.1, Double.MaxValue, ErrorMessage = "Пожалуйста, введите корректное значение")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите корректное значение")]
        public string Category { get; set; } 

        public DateTime? SpentOn { get; set; }
    }
}
