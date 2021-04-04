using EventData.Context;
using EventData.DataContracts;
using EventData.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EventServices
{
    public class EventService : IEventService
    {
        private EventDataContext _context;

        public EventService(EventDataContext context)
        {
            _context = context;
        }

        public Event AddNewEvent(Event @event)
        {
            @event.DateAdded = DateTime.Now;

            if (@event.DateAdded >= @event.DateHappens)
                throw new InvalidOperationException("Invalid event start date! The date happens cannot be less than or equal to the date added!");

            var added = _context.Add(@event);
            _context.SaveChanges();

            return added.Entity;
        }

        public void ArchiveEvent(Event @event)
        {
            _context.ArchivedEvents.Add(new ArchivedEvent()
            {
                Event = @event,
                DateArchived = DateTime.Now
            });
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            // Exclude archived events
            var archivedEventsIds = _context.ArchivedEvents.Select(ae => ae.Event.Id);
            return _context.Events.Where(e => !archivedEventsIds.Contains(e.Id));
        }

        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public Event GetByName(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}
