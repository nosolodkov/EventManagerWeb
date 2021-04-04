using EventData.Context;
using EventData.DataContracts;
using EventData.Models;
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

        public bool AddMultipleGuests(List<Guest> guests)
        {
            throw new NotImplementedException();
        }

        public bool AddNewGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guest> GetAll()
        {
            return _context.Guests;
        }

        public Guest GetByEMail(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Guest GetByName(string firstName, string lastName, string patronymic = null)
        {
            return _context.Guests
                .FirstOrDefault(g =>
                    g.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    g.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(patronymic, g.Patronymic, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
