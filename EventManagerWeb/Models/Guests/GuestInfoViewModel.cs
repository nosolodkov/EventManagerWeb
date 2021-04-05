using EventManagerWeb.Models.Events;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagerWeb.Models.Guests
{
    public class GuestInfoViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Comment { get; set; }

        public IEnumerable<EventInfoViewModel> ListOfEvents { get; set; } = new List<EventInfoViewModel>();

        public EventInfoViewModel AssociatedEvent { get; set; }
    }
}
