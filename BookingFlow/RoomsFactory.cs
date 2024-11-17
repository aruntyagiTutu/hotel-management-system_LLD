namespace HMS
{

    // RoomFactory to create Room objects based on the room type
    public class RoomFactory
    {
        public Room GetRoom(string roomType)
        {
            if (roomType == null)
            {
                return null;
            }

            switch (roomType.ToLower())
            {
                case "standard":
                    return new StandardRoom();
                case "deluxe":
                    return new DeluxeRoom();
                case "suite":
                    return new SuiteRoom();
                default:
                    return null;
            }
        }
    }
}