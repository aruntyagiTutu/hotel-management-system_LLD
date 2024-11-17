
using System.Collections.Generic;
using System.Linq;

namespace HMS
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Room> GetAvailableRooms();
        Room GetRoomByNumber(int roomNumber);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
    }


    public class RoomRepository : IRoomRepository
    {
        private readonly List<Room> _rooms;

        public RoomRepository()
        {
            _rooms = new List<Room>();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _rooms;
        }

        public IEnumerable<Room> GetAvailableRooms()
        {
            return _rooms.Where(r => r.IsAvailable);
        }

        public Room GetRoomByNumber(int roomNumber)
        {
            return _rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            var existingRoom = GetRoomByNumber(room.RoomNumber);
            if (existingRoom != null)
            {
                existingRoom.RoomType = room.RoomType;
                existingRoom.Price = room.Price;
                existingRoom.IsAvailable = room.IsAvailable;
            }
        }
    }

}