using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IEventService
    {
        IEnumerable<Event> GetAll();

        Event GetByName(string eventName);

        Event GetById(int id);

        Event AddOrUpdate(Event @event);

        void ArchiveEvent(Event @event);

        List<string> GetAllEventTypes();
    }
}
