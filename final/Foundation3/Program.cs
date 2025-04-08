using System;

class Program
{
    static void Main(string[] args)
    {
        // Address instances
        Address address1 = new Address("100 Main St", "Rexburg", "ID", "USA");
        Address address2 = new Address("200 Oak Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("Park Lane", "Seattle", "WA", "USA");

        // Events
        Lecture lecture = new Lecture("Tech Conference", "A lecture on future technologies", "2025-05-20", "10:00 AM", address1, "Dr. Smith", 100);
        Reception reception = new Reception("Networking Event", "Meet and connect with professionals", "2025-06-15", "6:00 PM", address2, "rsvp@example.com");
        OutdoorGathering outdoor = new OutdoorGathering("Community Picnic", "Family fun in the sun", "2025-07-10", "12:00 PM", address3, "Sunny with a chance of clouds");

        // Display each event
        Event[] events = { lecture, reception, outdoor };

        foreach (Event evt in events)
        {
            Console.WriteLine("===== Standard Details =====");
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine("\n===== Full Details =====");
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine("\n===== Short Description =====");
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine("\n----------------------------\n");
        }
    }
}
