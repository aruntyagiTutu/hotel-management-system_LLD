namespace HMS
{
    public interface IBookingHandler
    {
        void SetNext(IBookingHandler nextHandler);
        void Handle(BookingRequest request);
    }


    public class RoomAvailabilityHandler : IBookingHandler
    {
        private IBookingHandler _nextHandler;

        public void SetNext(IBookingHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(BookingRequest request)
        {
            if (request.Room.IsAvailable)
            {
                Console.WriteLine("Room is available.");
                _nextHandler?.Handle(request);
            }
            else
            {
                Console.WriteLine("Room is not available. Booking request denied.");
            }
        }
    }

    public class DiscountHandler : IBookingHandler
    {
        private IBookingHandler _nextHandler;

        public void SetNext(IBookingHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(BookingRequest request)
        {
            if (request.IsDiscountEligible)
            {
                Console.WriteLine("Applying discount.");
                request.TotalCost *= 0.9; // 10% discount
            }
            _nextHandler?.Handle(request);
        }
    }


    public class BookingRequest
    {
        public Room Room { get; set; }
        public double TotalCost { get; set; }
        public bool IsDiscountEligible { get; set; }

        public BookingRequest(Room room, double totalCost, bool isDiscountEligible)
        {
            Room = room;
            TotalCost = totalCost;
            IsDiscountEligible = isDiscountEligible;
        }
    }

}