namespace skeleton
{
    public class User
    {
        public string Name{ get; set; }
        public string Email{ get; set; }
        public string Phone{ get; set; }

    }

    public class Receptionist: User
    {
        public bool CreateBooking(User guest, Room room)
        {
            return true;
        }

        public RoomKey IssueKey(Room room)
        {
            return new RoomKey(){
                RoomNumber = room.Number
            };
        }
    }

    public class Guest
    {
        ISearchRoom searchService;
        public Guest(ISearchRoom searchRoom)
        {
            searchService = searchRoom;
        }
        public List<Room> SearchRooms(int guests, DateTime checkin, int duration)
        {
            return searchService.SearchByOccupancy(guests, checkin, duration);
        }

        public bool BookRoom(Room room, DateTime checkin, int duration)
        {
            RoomBooking booking = new RoomBooking(){
                room = room,
                CheckIn = new DateTime(),
                CheckOut = new DateTime()
            };
            return true;
        }
    }
}