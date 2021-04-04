using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventData.Models
{
    /// <summary>
    /// Describes the guest model.
    /// </summary>
    public class Guest
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [Required]
        public string Email { get; set; }

        public string Comment { get; set; }


        public Guest(string firstName, string lastName, string patronymic, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name must be required!", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name must be required!", nameof(lastName));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Correct email address must be required!", nameof(email));

            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Email = email;
        }
    }
}
