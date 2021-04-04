using EventData.DataContracts;
using EventData.Models;
using System;
using System.Collections.Generic;

namespace EventServices
{
    public class EventService : IEventService
    {
        public bool AddNewEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public void ArchiveEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Event GetByName(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}
