using Microsoft.AspNetCore.Mvc;
using ThirdAPI.Models;

namespace hotelbigbang.Repositories.Rooms
{
    public interface IRoomService
    {

        Task<IEnumerable<Room>> GetRoom();
        Task<Room?> GetRoom(int id);
        Task<Room> PutEmp(int id, Room room);
        Task<List<Room>> PostRoom(Room room);
        Task<Room> DeleteRoom(int id);
    }
}
