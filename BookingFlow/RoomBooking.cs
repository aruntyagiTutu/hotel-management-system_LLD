namespace HMS
{
    public abstract class RoomBooking : INotificationSubject
    {
        private readonly RoomSearchService roomSearchService;
        public RoomBooking(RoomSearchService roomSearchService)
        {
            this.roomSearchService = roomSearchService;
        }
        public Booking BookRoom(Room room)
        {
            int roomNumber = room.RoomNumber;
            CheckAvailability(roomNumber);

            GetCustomerDetails();
            ProcessPayment();
            Booking booking = ConfirmBooking(room);


            NotifyObservers(booking);
            return booking;

        }

        protected abstract void GetCustomerDetails();
        protected abstract void ProcessPayment();

        private Room CheckAvailability(int roomNumber)
        {
            Console.WriteLine($"Checking availability for room {roomNumber}...");
            Room room = roomSearchService.GetByNumber(roomNumber);
            return room;
            // Logic for checking room availability
        }

        private Booking ConfirmBooking(Room room)
        {
            Console.WriteLine($"Booking confirmed for room {room.RoomNumber}.");
            // Logic for confirming booking
            return new RegularBooking()
            {
                Room = room
            };
        }

        private void SendConfirmation()
        {
            Console.WriteLine("Sending confirmation email to the customer...");
            // Logic for sending confirmation
        }

        private List<INotificationObserver> observers = new List<INotificationObserver>();

        public void RegisterObserver(INotificationObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(INotificationObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(Booking booking)
        {
            foreach (var observer in observers)
            {
                observer.Update(booking);
            }
        }
    }

    public class OnlineBooking : RoomBooking
    {
        public OnlineBooking(RoomSearchService roomSearchService) : base(roomSearchService)
        {
        }

        protected override void GetCustomerDetails()
        {
            Console.WriteLine("Collecting customer details online...");
            // Logic to collect customer details for online booking
        }

        protected override void ProcessPayment()
        {
            Console.WriteLine("Processing online payment...");
            // Logic to process payment online
        }
    }

    public class WalkInBooking : RoomBooking
    {
        public WalkInBooking(RoomSearchService roomSearchService) : base(roomSearchService)
        {
        }

        protected override void GetCustomerDetails()
        {
            Console.WriteLine("Collecting customer details at the front desk...");
            // Logic to collect customer details for walk-in booking
        }

        protected override void ProcessPayment()
        {
            Console.WriteLine("Processing payment at the front desk...");
            // Logic to process payment for walk-in booking
        }
    }


}