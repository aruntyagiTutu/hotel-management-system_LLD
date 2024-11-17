using skeleton;
namespace HMS
{
    public interface IRoomSearch
    {
        List<Room> GetAvailableRooms();
        Room FindRoomByNumber(int roomNumber);
        List<Room> GetRoomsByType(RoomType type);
    }

    public class RoomSearch : IRoomSearch
    {
        private readonly IRoomRepository _roomRepository;

        public RoomSearch(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Room> GetAvailableRooms()
        {
            return _roomRepository.GetAllRooms().Where(r => r.IsAvailable).ToList();
        }

        public Room FindRoomByNumber(int roomNumber)
        {
            return _roomRepository.GetAllRooms().FirstOrDefault(r => r.RoomNumber == roomNumber);
        }

        public List<Room> GetRoomsByType(RoomType type)
        {
            return _roomRepository.GetAllRooms().Where(r => r.RoomType == type).ToList();
        }
    }
}