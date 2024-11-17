Template Method Pattern:

Use Case: Defining the skeleton of an algorithm for booking a room but allowing certain steps to be modified by subclasses.

Example: Different types of bookings (online, phone, walk-in) could follow the same basic flow but allow certain steps (like payment or room assignment) to be customized.

public abstract class RoomBooking
{
    public void BookRoom(int roomNumber)
    {
        CheckAvailability(roomNumber);
        GetCustomerDetails();
        ProcessPayment();
        ConfirmBooking(roomNumber);
        SendConfirmation();
    }

    protected abstract void GetCustomerDetails();
    protected abstract void ProcessPayment();
    
    private void CheckAvailability(int roomNumber)
    {
        Console.WriteLine($"Checking availability for room {roomNumber}...");
        // Logic for checking room availability
    }

    private void ConfirmBooking(int roomNumber)
    {
        Console.WriteLine($"Booking confirmed for room {roomNumber}.");
        // Logic for confirming booking
    }

    private void SendConfirmation()
    {
        Console.WriteLine("Sending confirmation email to the customer...");
        // Logic for sending confirmation
    }
}


public class OnlineBooking : RoomBooking
{
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


public class PhoneBooking : RoomBooking
{
    protected override void GetCustomerDetails()
    {
        Console.WriteLine("Collecting customer details over the phone...");
        // Logic to collect customer details for phone booking
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing payment over the phone...");
        // Logic to process payment for phone booking
    }
}
