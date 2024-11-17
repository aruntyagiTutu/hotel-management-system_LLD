using skeleton;
namespace HMS
{
    // Define the Room interface or base class
    public abstract class Room
    {
        public int RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public abstract string GetDescription();
        public abstract double GetCost();
    }

    // Concrete Room types implementing the Room interface
    public class StandardRoom : Room
    {
        public override string GetDescription()
        {
            return "Standard Room";
        }

        public override double GetCost()
        {
            return 100.00;  // Example cost for a Standard Room
        }
    }

    public class DeluxeRoom : Room
    {
        public override string GetDescription()
        {
            return "Deluxe Room";
        }

        public override double GetCost()
        {
            return 200.00;  // Example cost for a Deluxe Room
        }
    }

    public class SuiteRoom : Room
    {
        public override string GetDescription()
        {
            return "Suite Room";
        }

        public override double GetCost()
        {
            return 400.00;  // Example cost for a Suite Room
        }
    }
}