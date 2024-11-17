namespace HMS
{
    public class User
    {
        private readonly RoomSearchService roomSearchService;
        private readonly BookingFactory bookingFactory;  // Assumes we are using a factory for creating bookings

        public User(RoomSearchService roomSearchService, BookingFactory bookingFactory)
        {
            this.roomSearchService = roomSearchService;
            this.bookingFactory = bookingFactory;
        }

        public User(RoomSearchService roomSearchService)
        {
            this.roomSearchService = roomSearchService;
        }

        public void HMSFlow()
        {
            // user is searching for a room
            Room room = SearchForRoom();

            // User is booking the selected room
            Booking booking = BookRoom(room);

            // User adding breakfast to the booking 
            Booking updatedBooking = AddExtraServiceToBooking(booking, "breakfast");

        }

        public Room SearchForRoom()
        {
            // The user initiates a search through the search service
            Console.WriteLine("User is searching for rooms...");
            return roomSearchService.SearchRoom();
        }


        public Booking BookRoom(Room selectedRoom)
        {
            Console.WriteLine($"Room {selectedRoom.RoomNumber} is available. Proceeding with booking...");

            // Create a booking for the selected room using the factory
            OnlineBooking onlineBooking = new OnlineBooking(this.roomSearchService);
            onlineBooking.RegisterObserver(new EmailNotification());

            Booking booking = onlineBooking.BookRoom(selectedRoom);

            // Confirm the booking details
            Console.WriteLine(booking.GetBookingDetails());
            Console.WriteLine($"Total cost: {booking.GetTotalCost()}");

            return booking;
            // (Optional) Process payment or confirmation steps if required.
        }


        public Booking AddExtraServiceToBooking(Booking booking, string service)
        {
            switch (service.ToLower())
            {
                case "wifi":
                    booking = new WiFiDecorator(booking);
                    break;
                case "breakfast":
                    booking = new BreakfastDecorator(booking);
                    break;
                // Add more services as needed
                default:
                    Console.WriteLine("Invalid service selected.");
                    break;
            }

            Console.WriteLine(booking.GetBookingDetails());
            Console.WriteLine($"Total cost after adding service: {booking.GetTotalCost()}");

            return booking;
        }

    }

}