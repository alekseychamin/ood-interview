namespace MovieTicket;

// xUnit test ported from JUnit 5

public class MovieBookingSystemTest {
    [Fact]
    public void TestBrowseAndBuy() {
        Console.WriteLine("\n=== Testing Movie Booking System: Browse and Buy Flow ===");
        MovieBookingSystem bookingSystem = new MovieBookingSystem();
        Console.WriteLine("\n--- Creating Room and Setting Up Seat Pricing ---");
        // create a room with a layout of 10x10 seats with a normal rate of $10.00
        Room room = new Room("1", new Layout(10, 10));
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                room.Layout.GetSeatByPosition(i, j).SetPricingStrategy(new NormalRate(10.00m));
            }
        }
        Console.WriteLine("✓ Created room '1' with 10x10 seats, each seat priced at $10.00");

        Console.WriteLine("\n--- Adding Cinema to Booking System ---");
        // create a cinema with the room
        bookingSystem.AddCinema(new Cinema("Test Cinema", "Test Location"));
        Console.WriteLine("✓ Added cinema: 'Test Cinema' at 'Test Location'");

        Console.WriteLine("\n--- Creating Movie and Screening ---");
        // create a test movie with a test screening in the room
        int length = 180;
        Movie movie = new Movie("Test Movie", "Test Description", length);
        Screening screening = new Screening(movie, room, DateTime.Now, DateTime.Now.AddMinutes(length));
        Console.WriteLine("✓ Created movie: 'Test Movie' (180 min)");
        Console.WriteLine("✓ Created screening for 'Test Movie' in room '1'");

        Console.WriteLine("\n--- Adding Movie and Screening to Booking System ---");
        // add the movie and screening to the booking system
        bookingSystem.AddMovie(movie);
        bookingSystem.AddScreening(movie, screening);
        Console.WriteLine("✓ Added movie and screening to booking system");

        Console.WriteLine("\n--- Verifying Movies and Screenings in System ---");
        // test that the movie and screening are in the booking system
        Assert.Equal(1, bookingSystem.AllMovies.Count);
        Assert.Equal(1, bookingSystem.GetScreeningsForMovie(movie).Count);
        Console.WriteLine("✓ Verified: 1 movie and 1 screening present in system");

        Console.WriteLine("\n--- Checking Available Seats ---");
        // test that the available seats for the screening are correct
        Assert.Equal(100, bookingSystem.GetAvailableSeats(screening).Count);
        Console.WriteLine("✓ Verified: 100 seats available for the screening");

        Console.WriteLine("\n--- Booking a Ticket ---");
        // test that the booking system can book a ticket
        bookingSystem.BookTicket(screening, room.Layout.GetSeatByPosition(0, 0));
        Assert.Equal(1, bookingSystem.GetTicketCount(screening));
        Console.WriteLine("✓ Booked seat (0,0) for 'Test Movie' screening");
        Console.WriteLine("✓ Verified: 1 ticket booked for the screening");

        Console.WriteLine("\n--- Checking Ticket Price ---");
        // test the price of the ticket
        Assert.Equal(10.00m, bookingSystem.GetTicketsForScreening(screening)[0].Price);
        Console.WriteLine("✓ Verified: Ticket price is $10.00");
        Console.WriteLine("=== Movie Booking System Test Completed Successfully ===\n");
    }
}
