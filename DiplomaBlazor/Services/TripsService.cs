using System;
namespace DiplomaBlazor.Services
{
    public class TripsService
    {
        private readonly DatabaseContext _context;

        public TripsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync(int pageNo = 1, int count = 10)
        {
            var query = await _context.GetTableAsync<Trip>();
            return await query.OrderByDescending(t => t.AdedOn)
                        .Skip((pageNo - 1) * count)
                        .Take(count)
                        .ToArrayAsync();
        }

        public async Task<MethodDataResult<Trip>> SaveTripAsync(Trip trip)
        {
            trip.Status = Enum.Parse<TripStatus>(trip.DisplayStatus);
            try
            {
                if (trip.Id == 0)
                {
                    //создать
                    await _context.AddItemAsync(trip);
                }
                else
                {
                    //изменить
                    await _context.UpdateItemAsync(trip);
                }
                return MethodDataResult<Trip>.Success(trip);
            }
            catch (Exception ex)
            {
                return MethodDataResult<Trip>.Fail(ex.Message);
            }
        }

        public async Task<Trip?> GetTripAsync(int tripId, bool includeExpenses = false)
        {
            var trip = await _context.FindAsync<Trip>(tripId);
            if (includeExpenses)
            {
                trip.Expenses = await _context.GetFileteredAsync<Expense>(e => e.TripId == tripId) ?? 
                    Enumerable.Empty<Expense>();
            }
            return trip;
        }

        public async Task<MethodDataResult<Expense>> SaveExpenseAsync(Expense expense)
        {          
            try
            {
                if (expense.Id == 0)
                {
                    //создать траты
                    await _context.AddItemAsync<Expense>(expense);
                }
                else
                {
                    //изменить
                    await _context.UpdateItemAsync<Expense>(expense);
                }
                return MethodDataResult<Expense>.Success(expense);
            }
            catch (Exception ex)
            {
                return MethodDataResult<Expense>.Fail(ex.Message);
            }
        }

        public async Task<Expense?> GetExpenseAsync(long expenseId) =>
            await _context.FindAsync<Expense>(expenseId);

        public async Task<MethodResult> SaveExpenseCategoryAsync(string categoryName)
        {
            var dbCategory = await _context.FindAsync<ExpenseCategory>(categoryName);
            if (dbCategory is not null)
            {
                return MethodResult.Fail($"Категория [{categoryName}] уже существует");
            }
            await _context.AddItemAsync<ExpenseCategory>(new ExpenseCategory(categoryName));
            return MethodResult.Success();
        }
    }
}
