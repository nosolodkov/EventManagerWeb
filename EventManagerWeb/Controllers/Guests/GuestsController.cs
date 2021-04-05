using EventData.DataContracts;
using EventData.Models;
using EventManagerWeb.Models.Events;
using EventManagerWeb.Models.Guests;
using EventServices.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerWeb.Controllers.Guests
{
    public class GuestsController : Controller
    {
        private IGuestService _guestService;
        private IEventService _eventService;

        [BindProperty]
        public GuestInfoViewModel Guest { get; set; }

        public GuestsController(IGuestService guestService, IEventService eventService)
        {
            _guestService = guestService;
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var allGuests = _guestService.GetAll();

            var model = new GuestsViewModel()
            {
                Guests = allGuests.Select(result => new GuestInfoViewModel
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Patronymic = result.Patronymic,
                    Email = result.Email,
                    Comment = result.Comment,
                    ListOfEvents = result.ListOfEvents.Select(e => new EventInfoViewModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                    })
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(int eventId)
        {
            if (ModelState.IsValid)
            {
                var associatedEvent = _eventService.GetById(eventId);

                try
                {
                    var added = _guestService.AddNewGuest(new Guest(
                    Guest.FirstName,
                    Guest.LastName,
                    Guest.Patronymic,
                    Guest.Email)
                    {
                        Id = Guest.Id,
                        Comment = Guest.Comment
                    }, associatedEvent);

                    return RedirectToAction("ManageGuests", "Events", associatedEvent != null ? new { id = associatedEvent.Id } : null);
                }
                catch (GuestIsAlreadyExistsException ex)
                {
                    ViewBag.ValidationErrorMessage = ex.Message;
                    return View(Guest);
                }
                catch (MaxGuestsForEventException mgex)
                {
                    ViewBag.ValidationErrorMessage = mgex.Message;
                    return View(Guest);
                }

            }

            return View(Guest);
        }

        public IActionResult AddOrUpdate(int? id, int? eventId)
        {
            Guest = new GuestInfoViewModel();

            if (eventId != null)
            {
                var associatedEvent = _eventService.GetById(eventId.Value);
                Guest.AssociatedEvent = new EventInfoViewModel
                {
                    Id = associatedEvent.Id,
                    Name = associatedEvent.Name,
                    MaxGuestsCount = associatedEvent.MaxGuestsCount,
                    AllEventTypes = _eventService.GetAllEventTypes(),
                };
            }

            //Guest.ListOfEvents.Add(Guest.AssociatedEvent);

            if (id == null)
            {
                // Add
            }
            else
            {
                // Edit
                var guestToEdit = _guestService.GetById(id.Value);
                if (guestToEdit == null) return NotFound();

                Guest.Id = guestToEdit.Id;
                Guest.FirstName = guestToEdit.FirstName;
                Guest.LastName = guestToEdit.LastName;
                Guest.Patronymic = guestToEdit.Patronymic;
                Guest.Email = guestToEdit.Email;
                Guest.Comment = guestToEdit.Comment;
            }

            return View(Guest);
        }

        [HttpPost]
        public IActionResult Remove(int id, int? eventId)
        {
            var guest = _guestService.GetById(id);
            var @event = eventId != null ? _eventService.GetById(eventId.Value) : null;

            _guestService.RemoveGuest(guest, @event);

            return RedirectToAction("ManageGuests", "Events", @event != null ? new { id = @event.Id } : null);
        }
    }
}
