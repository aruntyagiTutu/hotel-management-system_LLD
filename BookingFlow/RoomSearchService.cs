using skeleton;
namespace HMS
{
    public class RoomSearchService
    {
        private readonly IRoomSearch roomSearch;

        public RoomSearchService(IRoomSearch roomSearch)
        {
            this.roomSearch = roomSearch;
        }

        public Room SearchRoom()
        {
            // Get all available rooms
            var availableRooms = roomSearch.GetAvailableRooms();
            Console.WriteLine("Available Rooms:");
            foreach (var room in availableRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - {room.RoomType} - ${room.Price}");
            }

            // Search for room by number
            var specificRoom = roomSearch.FindRoomByNumber(103);
            Console.WriteLine($"\nSearch Result for Room 103: {specificRoom?.RoomNumber} - {specificRoom?.RoomType} - ${specificRoom?.Price}");

            // Get rooms by type
            var doubleRooms = roomSearch.GetRoomsByType(RoomType.Double);
            Console.WriteLine("\nDouble Rooms:");
            foreach (var room in doubleRooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} - {room.RoomType} - ${room.Price}");
            }

            return specificRoom;
        }

        public Room GetByNumber(int roomNumber)
        {
            return roomSearch.FindRoomByNumber(roomNumber);
        }
    }

}