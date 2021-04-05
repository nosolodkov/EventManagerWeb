using EventData.Context;
using EventData.DataContracts;
using EventData.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EventServices.Exceptions;

namespace EventServices
{
    public class EventService : IEventService
    {
        private EventDataContext _context;

        public EventService(EventDataContext context)
        {
            _context = context;
        }

        public Event AddOrUpdate(Event @event)
        {
            @event.DateAdded = DateTime.Now;

            if (@event.DateAdded >= @event.DateHappens)
                throw new InvalidEventHappensTimeException("Invalid event start date! The date happens cannot be less than or equal to the date added!");

            var eventAtDb = _context.Events.FirstOrDefault(e => e.Id == @event.Id);
            if (eventAtDb != null)
            {
                // Update
                _context.Update(eventAtDb);

                eventAtDb.Name = @event.Name;
                eventAtDb.Location = @event.Location;
                eventAtDb.EventTypeId = @event.EventTypeId;
                eventAtDb.DateHappens = @event.DateHappens;
                eventAtDb.Description = @event.Description;
                eventAtDb.MaxGuestsCount = @event.MaxGuestsCount;
                eventAtDb.ListOfGuests = @event.ListOfGuests;
            }
            else
            {
                // Create
                eventAtDb = _context.Add(@event).Entity;
            }

            _context.SaveChanges();

            return eventAtDb;
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
            return _context.Events.Include(a => a.ListOfGuests).Where(e => !archivedEventsIds.Contains(e.Id));
        }

        public Event GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public Event GetByName(string eventName)
        {
            return GetAll()
                .FirstOrDefault(e => string.Equals(e.Name, eventName, StringComparison.OrdinalIgnoreCase));
        }

        public List<string> GetAllEventTypes()
        {
            return _context.EventTypeVariants.Select(etv => etv.Name).ToList();
        }
    }
}
