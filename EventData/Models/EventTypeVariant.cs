using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventData.Models
{
    public class EventTypeVariant
    {
        [Key]
        public EventTypeId EventTypeId { get; set; }
        public string Name { get; set; }

        public List<EventType> EventTypes { get; set; }
    }
}
