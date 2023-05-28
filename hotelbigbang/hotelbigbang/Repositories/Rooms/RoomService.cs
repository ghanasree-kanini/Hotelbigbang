using Microsoft.EntityFrameworkCore;
using hotelbigbang.Model;

namespace hotelbigbang.Repositories.Rooms
{
    public class RoomServices : IRoomServices
    {
        public CompanyContext _companyContext;
        public RoomServices(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }
        public async Task<IEnumerable<Room>> GetRoom()
        {
            return await _companyContext.Room.ToListAsync();
        }
        public async Task<Room>?> GetRoom(int id)
        {
            var room = await _companyContext.Room.FindAsync(id);
            return room;
        }
        public async Task<Room> PutRoom(int id, Room room)
        {
            var item = await _companyContext.Room.FindAsync(id);
            item.Rno = room.Eno;
            item.Rname = room.Ename;
            await _companyContext.SaveChangesAsync();
            return room;
        }
        public async Task<List<Room>> PostRom(Room room)
        {
            var item = _companyContext.Room.AddAsync(room);
            await _companyContext.SaveChangesAsync();
            return await _companyContext.Room.ToListAsync();
        }
        public async Task<Room> DeleteRoom(int id)
        {
            var emp = await _companyContext.Emps.FindAsync(id);
            _companyContext.Emps.Remove(room);
            await _companyContext.SaveChangesAsync();
            return room;
        }
    }
}
