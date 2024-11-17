Observer Pattern:

Use Case: Notifying users or subsystems about room availability, booking status changes, or promotions.

Example: Notify customers when a room they want becomes available or when a booking is confirmed or canceled. Also, use it to trigger other actions like sending emails or updates to the system.

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