namespace skeleton
{
    public class RoomKey
    {
        public int Id { get; set;}
        public bool IsActive{ get; set;}

        public int RoomNumber{ get; set;}

        public bool AssignToRoom(Room room)
        {
            RoomNumber = room.Number;
            return true;
        }
    }
}