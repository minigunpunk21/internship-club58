using Club58Bot;

namespace Club58_Bot;

public class MockClubEventService : IClubEventService
{
    public List<Event> GetEvents()
    {
        return new List<Event>
        {
            new Event { Id = 1, Name = "Event 1" },
            new Event { Id = 2, Name = "Event 2" }
        };
    }
}