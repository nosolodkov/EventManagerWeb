using EventData.Context;
using EventData.DataContracts;
using EventData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventServices
{
    public class GuestService : IGuestService
    {
        private EventDataContext _context;

        public GuestService(EventDataContext context)
        {
            _context = context;
        }

        public IGuestsImporter Importer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IGuestsExporter Exporter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool AddMultipleGuests(List<Guest> guests, Event @event)
        {
            throw new NotImplementedException();
        }

        public Guest AddNewGuest(Guest guest, Event @event)
        {
            guest.ListOfEvents.Add(@event);

            var added = _context.Add(guest);
            _context.SaveChanges();
            return added.Entity;
        }

        public IEnumerable<Guest> GetAll()
        {
            return _context.Guests.Include(a => a.ListOfEvents);
        }

        public Guest GetByEMail(string emailAddress)
        {
            return GetAll()
                .FirstOrDefault(g => string.Equals(g.Email, emailAddress, StringComparison.OrdinalIgnoreCase));
        }

        public Guest GetById(int id)
        {
            return GetAll().FirstOrDefault(g => g.Id == id);
        }

        public Guest GetByName(string firstName, string lastName, string patronymic = null)
        {
            return GetAll()
                .FirstOrDefault(g =>
                    g.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    g.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(patronymic, g.Patronymic, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveGuest(Guest guest, Event @event)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == @event.Id);
            ev.ListOfGuests.Remove(guest);
            _context.Remove(guest);
            _context.SaveChanges();
        }
    }
}
