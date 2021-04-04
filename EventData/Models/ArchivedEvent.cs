using System;

namespace EventData.Models
{
    public class ArchivedEvent
    {
        public int Id { get; set; }

        public DateTime DateArchived { get; set; }

        public Event Event { get; set; }
    }
}
