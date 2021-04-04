using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAll();

        Guest GetByName(string firstName, string lastName, string patronymic = null);

        Guest GetByEMail(string emailAddress);

        bool AddNewGuest(Guest guest);

        void RemoveGuest(Guest guest);

        bool AddMultipleGuests(List<Guest> guests);

        IGuestsImporter Importer { get; set; }

        IGuestsExporter Exporter { get; set; }
    }
}
