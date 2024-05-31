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

        public async Task<Trip?> GetTripAsync(int tripId)
        {
            return await _context.FindAsync<Trip>(tripId);
        }
    }
}
