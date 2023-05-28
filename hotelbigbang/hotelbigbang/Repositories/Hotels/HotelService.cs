using Microsoft.EntityFrameworkCore;
using ThirdAPI.Models;

namespace hotelbigbang.Repositories.Hotel
{
    public class HotelService: IDeptServices
    {
        public CompanyContext _companyContext;
        public HotelService(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
        public async Task<IEnumerable<Hotel>> GetHotel()
        {
            return await _companyContext.Hotel.ToListAsync();

        }
        public async Task<Hotel>? GetHotel(int id)
        {
            var Hotel = await _companyContext.Hotel.FindAsync(id);
            return Hotel;
        }
        public async Task<Hotel> PutDept(int id, Hotel Hotel)
        {
            var item = await _companyContext.Hotel.FindAsync(id);

            item.HotelNo = Hotel.HotelNo;
            item.HotelName = Hotel.HotelName;
            await _companyContext.SaveChangesAsync();
            return Hotel;

        }
        public async Task<List<Hotel>> PostHotel(Hotel hotel)
        {
            await _companyContext.Hotel.AddAsync(hotel);
            await _companyContext.SaveChangesAsync();
            return await _companyContext.Hotel.ToListAsync();
        }
        public async Task<Hotel>? DeleteHotel(int id)
        {
            var hotel = await _companyContext.Hotel.FindAsync(id);
            _companyContext.Hotel.Remove(hotel);
            await _companyContext.SaveChangesAsync();
            return hotel;

        }
    }
    public async Task<int> GetAvailableRoomCount(int hotelId)
    {
        var hotel = await _AppDbcontext.Hotels
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.HotelId == hotelId);

        if (hotel == null)
            return 0;

        var availableRoomCount = hotel.Rooms.Count(r => r.Availability);
        return availableRoomCount;
    }
    public async Task<List<Hotel>> FilterHotels(string location, decimal? minPrice, decimal? maxPrice, string[] amenities)
    {
        var query = _AppDbcontext.Hotels.AsQueryable();

        if (!string.IsNullOrEmpty(location))
        {
            query = query.Where(h => h.Hotel_Location.Contains(location));
        }
        var filteredHotels = await query.ToListAsync();

        return filteredHotels;

    }