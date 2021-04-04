using EventData.DataContracts;
using EventData.Models;
using System;
using System.Collections.Generic;

namespace EventServices
{
    public class GuestService : IGuestService
    {
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
            throw new NotImplementedException();
        }

        public Guest GetByEMail(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Guest GetByName(string firstName, string lastName, string patronymic = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
