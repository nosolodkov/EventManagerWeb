using EventData.Models;
using Microsoft.EntityFrameworkCore;

namespace EventData.Context
{
    public class EventDataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<ArchivedEvent> ArchivedEvents { get; set; }

        public DbSet<Guest> Guests { get; set; }


        public EventDataContext(DbContextOptions<EventDataContext> options) : base(options) { }
    }
}
