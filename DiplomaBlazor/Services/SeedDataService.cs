using DiplomaBlazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var foodCategory = await _context.FindAsync<ExpenseCategory>("Еда");//food

            if (foodCategory is not null) 
                return; // Уже отправлено


            var expenseCategories = new List<ExpenseCategory>()
            {
                new("Еда"), new("Топливо"), new("Покупки"), new("Другое") //food fuel shopping other
            };

            var locationCategories = new List<LocationCategory>
            {
                new LocationCategory("Пляж", "/images/beach.png"),
                new LocationCategory("Город", "/images/city.png"),
                new LocationCategory("Горы", "/images/mountains.png"),
                new LocationCategory("Дорожное", "/images/car.png"),
                new LocationCategory("Другое", "/images/other.png")
                //добавить категории и картинки
            };

            foreach (var location in locationCategories) 
            {
                await _context.AddItemAsync<LocationCategory>(location);
            }

            

            foreach (var expenseCategory in expenseCategories)
            {
                await _context.AddItemAsync<ExpenseCategory>(expenseCategory);
            }
        }
    }
}
