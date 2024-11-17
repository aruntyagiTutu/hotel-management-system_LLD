namespace skeleton
{
    public class RoomBooking
    {
        public Room room;
        public DateTime CheckIn{ get; set; }
        public DateTime CheckOut{ get; set;}
        public PaymentStatus PaymentStatus{ get; set; }
        public BookingState State{ get; set; }
    }

    public enum PaymentStatus
    {
        Unknown,
        InProgress,
        Done
    }
    public enum BookingState
    {
        Unknown,
        Booked,
        Canceled,
        Confirmed
    }
}