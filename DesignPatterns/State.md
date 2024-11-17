State Pattern:

Use Case: Managing the various states of a booking (e.g., reserved, confirmed, checked-in, checked-out, canceled).

Example: A booking can transition between states like pending, confirmed, or canceled, and each state may have specific behaviors and rules.

public interface IBookingState
{
    void Next(Booking booking);
    void Previous(Booking booking);
    void PrintStatus();
}


public class ReservedState : IBookingState
{
    public void Next(Booking booking)
    {
        booking.SetState(new ConfirmedState());
    }

    public void Previous(Booking booking)
    {
        Console.WriteLine("The booking is in its initial state (Reserved).");
    }

    public void PrintStatus()
    {
        Console.WriteLine("Booking is in Reserved state.");
    }
}


public class ConfirmedState : IBookingState
{
    public void Next(Booking booking)
    {
        booking.SetState(new CheckedInState());
    }

    public void Previous(Booking booking)
    {
        booking.SetState(new ReservedState());
    }

    public void PrintStatus()
    {
        Console.WriteLine("Booking is in Confirmed state.");
    }
}


public class CheckedInState : IBookingState
{
    public void Next(Booking booking)
    {
        booking.SetState(new CheckedOutState());
    }

    public void Previous(Booking booking)
    {
        booking.SetState(new ConfirmedState());
    }

    public void PrintStatus()
    {
        Console.WriteLine("Booking is in Checked-In state.");
    }
}
