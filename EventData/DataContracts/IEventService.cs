using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();

        Event GetByName(string eventName);

        Event GetById(int id);

        Event AddNewEvent(Event @event);

        void ArchiveEvent(Event @event);
    }
}
