using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();

        Event GetByName(string eventName);

        bool AddNewEvent(Event @event);

        void ArchiveEvent(Event @event);
    }
}
