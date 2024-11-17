Decorator Pattern:

Use Case: Adding optional services or features (e.g., breakfast, airport pickup, or spa services) to a booking.

Example: Decorators allow you to dynamically add these features to a booking object, keeping the core booking class flexible and easy to extend.


Create Decorator Base Class

public abstract class BookingDecorator : Booking
{
    protected Booking _booking;

    public BookingDecorator(Booking booking)
    {
        _booking = booking;
    }

    public override string GetBookingDetails()
    {
        return _booking.GetBookingDetails();
    }

    public override double GetTotalCost()
    {
        return _booking.GetTotalCost();
    }
}

Create Concrete Decorators

// Concrete Decorator: Adds Breakfast to the booking
public class BreakfastDecorator : BookingDecorator
{
    public BreakfastDecorator(Booking booking) : base(booking) { }

    public override string GetBookingDetails()
    {
        return base.GetBookingDetails() + ", with Breakfast";
    }

    public override double GetTotalCost()
    {
        return base.GetTotalCost() + 50.00;  // Example: adding breakfast costs $50
    }
}

// Concrete Decorator: Adds Parking to the booking
public class ParkingDecorator : BookingDecorator
{
    public ParkingDecorator(Booking booking) : base(booking) { }

    public override string GetBookingDetails()
    {
        return base.GetBookingDetails() + ", with Parking";
    }

    public override double GetTotalCost()
    {
        return base.GetTotalCost() + 30.00;  // Example: adding parking costs $30
    }
}

// Concrete Decorator: Adds WiFi to the booking
public class WiFiDecorator : BookingDecorator
{
    public WiFiDecorator(Booking booking) : base(booking) { }

    public override string GetBookingDetails()
    {
        return base.GetBookingDetails() + ", with WiFi";
    }

    public override double GetTotalCost()
    {
        return base.GetTotalCost() + 10.00;  // Example: adding WiFi costs $10
    }
}
