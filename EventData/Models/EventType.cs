using System;
using System.Collections.Generic;
using System.Text;

namespace EventData.Models
{
    public class EventType
    {
        public int EventId { get; set; }
        public int Name { get; set; }

        public EventTypeId EventTypeId { get; set; }
        public EventTypeVariant EventTypeVariant { get; set; }
    }
}
