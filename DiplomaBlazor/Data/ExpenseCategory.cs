using SQLite;
using MaxLengthAttribute = System.ComponentModel.DataAnnotations.MaxLengthAttribute;


namespace DiplomaBlazor.Data
{
    public class ExpenseCategory
    {
        public ExpenseCategory(string name)
        {
            Name = name;
        }

        public ExpenseCategory()
        {
           
        }

        [PrimaryKey, MaxLength(100)]
        public string Name { get; set; }


    }
}
