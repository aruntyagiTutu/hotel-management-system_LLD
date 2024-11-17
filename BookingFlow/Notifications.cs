namespace HMS
{

    public interface INotificationObserver
    {
        void Update(Booking booking);
    }

    public interface INotificationSubject
    {
        void RegisterObserver(INotificationObserver observer);
        void RemoveObserver(INotificationObserver observer);
        void NotifyObservers(Booking booking);
    }

    public class EmailNotification : INotificationObserver
    {
        public EmailNotification()
        {
        }

        public void Update(Booking booking)
        {
            Console.WriteLine($"Email sent to user: Room {booking.Room.RoomNumber} has been booked successfully.");
        }
    }

    public class SmsNotification : INotificationObserver
    {
        public void Update(Booking booking)
        {
            Console.WriteLine($"SMS sent to user: Room {booking.Room.RoomNumber} has been booked successfully.");
        }
    }


}