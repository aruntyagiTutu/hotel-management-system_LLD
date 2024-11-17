Factory Pattern:


Use Case: Creating different types of bookings, rooms, or payment methods.

Example: You can use a factory to generate room types (deluxe, suite, etc.) or payment methods based on the user’s selection. It abstracts the creation process and promotes loose coupling.


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



public class BookingFactory
{
    private RoomFactory roomFactory = new RoomFactory();

    public Booking GetBooking(string bookingType, string roomType)
    {
        Room room = roomFactory.GetRoom(roomType);

        if (room == null)
        {
            return null;  // If the room type doesn't exist, return null
        }

        switch (bookingType.ToLower())
        {
            case "regular":
                return new RegularBooking { Room = room };
            case "advance":
                return new AdvanceBooking { Room = room };
            default:
                return null;
        }
    }
}