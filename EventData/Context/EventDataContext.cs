using EventData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EventData.Context
{
    public class EventDataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<ArchivedEvent> ArchivedEvents { get; set; }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<EventTypeVariant> EventTypeVariants { get; set; }


        public EventDataContext(DbContextOptions<EventDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EventType>()
                .Property(e => e.EventTypeId)
                .HasConversion<int>();

            modelBuilder
                .Entity<EventTypeVariant>()
                .Property(e => e.EventTypeId)
                .HasConversion<int>();

            modelBuilder
                .Entity<EventTypeVariant>().HasData(
                    Enum.GetValues(typeof(EventTypeId))
                        .Cast<EventTypeId>()
                        .Select(e => new EventTypeVariant()
                        {
                            EventTypeId = e,
                            Name = e.ToString()
                        })
                );
        }
    }
}
