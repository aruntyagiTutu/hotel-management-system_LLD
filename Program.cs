// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using HMS;
using Microsoft.Extensions.DependencyInjection;



class Program
{
    static void Main(string[] args)
    {
        // Set up the dependency injection container
        var serviceProvider = new ServiceCollection()
            .AddTransient<RoomSearchService>() 
            .AddTransient<IRoomSearch, RoomSearch>()
            .AddSingleton<IRoomRepository, RoomRepository>()
            .AddTransient<BookingFactory>()
            .AddTransient<User>()                            // Register User class
            .BuildServiceProvider();

        // Get the User instance from the service provider
        CreateRooms(serviceProvider);
        var user = serviceProvider.GetService<User>();
        user.HMSFlow();

        //Console.WriteLine("Hello, World!");
    }


    public static void CreateRooms(ServiceProvider serviceProvider)
    {
        var roomRepository = serviceProvider.GetService<IRoomRepository>();
        // Add some sample rooms
        roomRepository.AddRoom(new StandardRoom
        {
            RoomNumber = 101,
            RoomType = skeleton.RoomType.Single,
            IsAvailable = true,
            Price = 100
        });

        roomRepository.AddRoom(new DeluxeRoom
        {
            RoomNumber = 102,
            RoomType = skeleton.RoomType.Deluxe,
            IsAvailable = false, // Unavailable room
            Price = 150
        });

        
        roomRepository.AddRoom(new DeluxeRoom
        {
            RoomNumber = 103,
            RoomType = skeleton.RoomType.Deluxe,
            IsAvailable = false, // Unavailable room
            Price = 150
        });

        roomRepository.AddRoom(new SuiteRoom
        {
            RoomNumber = 201,
            RoomType = skeleton.RoomType.Suite,
            IsAvailable = true,
            Price = 300
        });
    }
}