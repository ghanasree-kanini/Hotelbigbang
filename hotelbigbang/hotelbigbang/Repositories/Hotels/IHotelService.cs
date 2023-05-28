namespace hotelbigbang.Repositories.Hotels
{
    public interface IHotelService
    {

        Task<IEnumerable<Hotel>> GetHotel();
        Task<Hotel>? GetHotel(int id);
        Task<Hotel> PutHotel(int id, Hotel hotel);
        Task<List<Hotel>> PostHotel(Hotel hotel);
        Task<Hotel>? DeleteHotel(int id);
        Task<int> GetAvailableRoomCount(int hotelId);
        Task<List<Hotel>> FilterHotels(string location);
    }
}
 
