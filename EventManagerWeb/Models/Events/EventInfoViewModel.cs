using EventManagerWeb.Models.Guests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerWeb.Models.Events
{
    public class EventInfoViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the event.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Event type.
        /// </summary>
        [Required]
        public string EventType { get; set; }

        /// <summary>
        /// The date when the event was added to the system.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// The date of the event.
        /// </summary>
        //[DisplayName("Date Happens")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime DateHappens { get; set; }

        /// <summary>
        /// The location of the event.
        /// </summary>
        [Required]
        public string Location { get; set; }

        /// <summary>
        /// The current number of guests.
        /// </summary>
        public int GuestsCount { get; set; }

        /// <summary>
        /// The maximum possible number of guests.
        /// </summary>
        public int? MaxGuestsCount { get; set; }

        /// <summary>
        /// The remaining number of seats for guests.
        /// </summary>
        public int? RemainingNumberOfSeats
        {
            get
            {
                return MaxGuestsCount.HasValue ? (int?)(MaxGuestsCount.Value - GuestsCount) : null;
            }
        }

        /// <summary>
        /// List of invited guests.
        /// </summary>
        public List<GuestInfoViewModel> ListOfGuests { get; set; }
    }
}
