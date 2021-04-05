using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventData.Models
{
    /// <summary>
    /// Defines possible types of <see cref="Event"/>.
    /// </summary>
    public enum EventTypeId : int
    {
        Conference = 0,
        Seminar = 1,
        Hackathon = 2
    }

    /// <summary>
    /// Represents the event model.
    /// </summary>
    public class Event
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        /// Event type id.
        /// </summary>
        public EventTypeId EventTypeId { get; set; }


        /// <summary>
        /// The date when the event was added to the system.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// The date of the event.
        /// </summary>
        public DateTime DateHappens { get; set; }

        /// <summary>
        /// The location of the event.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The current number of guests.
        /// </summary>
        public int GuestsCount { get { return ListOfGuests.Count; } }

        /// <summary>
        /// The maximum possible number of guests.
        /// </summary>
        public int? MaxGuestsCount { get; set; }

        /// <summary>
        /// The remaining number of seats for guests.
        /// </summary>
        [Required]
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
        public List<Guest> ListOfGuests { get; set; } = new List<Guest>();
    }
}
