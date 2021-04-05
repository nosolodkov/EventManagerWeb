using EventManagerWeb.Models.Events;
using System.Collections.Generic;

namespace EventManagerWeb.Models.Guests
{
    public class GuestInfoViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public IEnumerable<EventInfoViewModel> ListOfEvents { get; set; } = new List<EventInfoViewModel>();

        public EventInfoViewModel AssociatedEvent { get; set; }
    }
}
