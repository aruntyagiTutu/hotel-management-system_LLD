namespace HMS
{
    public class BookingSystemManager
    {
        // Step 2: Create a private static instance of the class
        private static BookingSystemManager _instance = null;

        // Step 3: Lock object for thread safety
        private static readonly object _lock = new object();

        // Step 4: Private constructor to prevent instantiation from outside
        private BookingSystemManager()
        {
            // Initialization code here, e.g., loading configurations, connecting to services, etc.
        }

        // Step 5: Public method to provide global access to the instance
        public static BookingSystemManager GetInstance()
        {
            // Ensure thread safety
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BookingSystemManager();
                    }
                }
            }
            return _instance;
        }

        // Example methods for the Booking System Manager
        public void ManageBooking(Booking booking)
        {
            // Logic to manage bookings
            Console.WriteLine("Managing booking for: " + booking.Room.RoomType);
        }

        public void CancelBooking(Booking booking)
        {
            // Logic to cancel bookings
            Console.WriteLine("Booking cancelled for: " + booking.Room.RoomType);
        }
    }

}