using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Services
{
    public class DropDownsService
    {
        private readonly DatabaseContext _context;

        public DropDownsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<LocationCategory[]> GetLocationCategoriesAsync()
        {
            return (await _context.GetAllAsync<LocationCategory>()).ToArray();
        }

        public string[] GetTripStatuses() => Enum.GetNames<TripStatus>();
    }
}
