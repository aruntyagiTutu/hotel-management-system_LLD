
namespace skeleton
{
    public class RoomCatalog: ISearchRoom
    {
        public List<Room> Rooms { get; set;}

        public RoomCatalog()
        {
            Rooms = new List<Room>();
            Rooms.Add(new Room(){
                MaxAccommodation = 2,
                IsSmoking = false,
                Number = 201,
                Type = RoomType.Double
            });
        }

        public List<Room> SearchByType(RoomType roomType, DateTime date, int duration)
        {
            return Rooms.FindAll(x=> x.Type == roomType);
        }

        public List<Room> SearchByOccupancy(int occupancy, DateTime date, int duration)
        {
            return Rooms.FindAll(x=> x.MaxAccommodation >= occupancy);
        }
    }
}