namespace skeleton
{
    public interface ISearchRoom
    {
        List<Room> SearchByType(RoomType roomType, DateTime date, int duration);
        List<Room> SearchByOccupancy(int occupancy, DateTime date, int duration);
    }
}