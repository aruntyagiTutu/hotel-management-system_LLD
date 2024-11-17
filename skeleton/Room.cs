namespace skeleton
{
    public class Room
    {
        public int Number{ get; set; }
        public RoomType Type{ get; set; }
        public bool IsSmoking{ get; set; }
        public int MaxAccommodation { get; set; }

        public bool IsAvailable()
        {
            return false;
        }

        public bool CheckIn()
        {
            return true;
        }

        public bool CheckOut()
        {
            return false;
        }
    }
}