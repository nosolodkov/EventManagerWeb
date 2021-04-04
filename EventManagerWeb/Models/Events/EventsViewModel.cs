using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerWeb.Models.Events
{
    public class EventsViewModel
    {
        public IEnumerable<EventInfoViewModel> Events { get; set; }
    }
}
