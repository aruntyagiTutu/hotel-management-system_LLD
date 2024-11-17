namespace HMS
{
    // Define the Booking interface or base class
    public abstract class Booking
    {
        
        public Room Room { get; set; }
        private IBookingState _currentState;

        public Booking()
        {
            // Initial state is reserved by default.
            _currentState = new ReservedState();
        }

        public void SetState(IBookingState state)
        {
            _currentState = state;
        }

        public void NextState()
        {
            _currentState.Next(this);
        }

        public void PreviousState()
        {
            _currentState.Previous(this);
        }

        public void PrintStatus()
        {
            _currentState.PrintStatus();
        }
        public abstract string GetBookingDetails();
        public abstract double GetTotalCost();
    }

    // Concrete Booking types implementing the Booking interface
    public class RegularBooking : Booking
    {
        public override string GetBookingDetails()
        {
            return $"Regular Booking - Room: {Room.GetDescription()}";
        }

        public override double GetTotalCost()
        {
            return Room.GetCost();
        }
    }

    public class AdvanceBooking : Booking
    {
        public override string GetBookingDetails()
        {
            return $"Advance Booking - Room: {Room.GetDescription()}";
        }

        public override double GetTotalCost()
        {
            return Room.GetCost() * 0.9;  // Example: 10% discount for advance booking
        }
    }

    // BookingFactory to create Booking objects based on the booking type
    public class BookingFactory
    {
        private RoomFactory roomFactory = new RoomFactory();

        public Booking GetBooking(string bookingType, Room room)
        {
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
}