namespace HMS
{
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


public class CheckedOutState : IBookingState
{
    public void Next(Booking booking)
    {
        Console.WriteLine("Booking is already checked out. No further state.");
    }

    public void Previous(Booking booking)
    {
        booking.SetState(new CheckedInState());
    }

    public void PrintStatus()
    {
        Console.WriteLine("Booking is in Checked-Out state.");
    }
}

}