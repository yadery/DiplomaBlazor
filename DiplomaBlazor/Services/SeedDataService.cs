using DiplomaBlazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Services
{
    public class SeedDataService
    {
        private readonly DatabaseContext _context;
        public SeedDataService(DatabaseContext context) 
        { 
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            var expenseCategories = new List<ExpenseCategory>()
            {
                new("Food"), new("Fuel"), new("Shopping"), new("Others")
            };

            var locationCategories = new List<LocationCategory>
            {
                new LocationCategory("Beach", "/images/")
                //добавить категории и картинки
            };

            foreach (var location in locationCategories) 
            {
                await _context.AddItemAsync(location);
            }

            foreach (var expenseCategory in expenseCategories)
            {
                await _context.AddItemAsync<ExpenseCategory>(expenseCategory);
            }
        }
    }
}
