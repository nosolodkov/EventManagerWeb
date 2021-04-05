using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAll();

        Guest GetById(int id);

        Guest GetByName(string firstName, string lastName, string patronymic = null);

        Guest GetByEMail(string emailAddress);

        Guest AddNewGuest(Guest guest, Event @event);

        void RemoveGuest(Guest guest, Event @event);

        bool AddMultipleGuests(List<Guest> guests, Event @event);

        IGuestsImporter Importer { get; set; }

        IGuestsExporter Exporter { get; set; }
    }
}
