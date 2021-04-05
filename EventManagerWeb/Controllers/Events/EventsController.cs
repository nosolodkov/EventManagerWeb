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

namespace EventManagerWeb.Controllers.Events
{
    public class EventsController : Controller
    {
        private IEventService _eventService;

        [BindProperty]
        public EventInfoViewModel Event { get; set; }


        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var allEvents = _eventService.GetAll();

            var model = new EventsViewModel()
            {
                Events = allEvents.Select(result => new EventInfoViewModel
                {
                    Id = result.Id,
                    DateAdded = result.DateAdded,
                    DateHappens = result.DateHappens,
                    Description = result.Description,
                    EventType = result.EventTypeId.ToString("G"),
                    AllEventTypes = _eventService.GetAllEventTypes(),
                    Location = result.Location,
                    MaxGuestsCount = result.MaxGuestsCount,
                    Name = result.Name,
                    ListOfGuests = result.ListOfGuests.Select(g => new GuestInfoViewModel()
                    {
                        Id = g.Id,
                        Email = g.Email,
                        FirstName = g.FirstName,
                        LastName = g.LastName,
                        Patronymic = g.Patronymic,
                        Comment = g.Comment,
                    })
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var added = _eventService.AddOrUpdate(new Event()
                    {
                        Name = Event.Name,
                        Description = Event.Description,
                        DateAdded = DateTime.Now,
                        DateHappens = Event.DateHappens,
                        Location = Event.Location,
                        MaxGuestsCount = Event.MaxGuestsCount,
                        EventTypeId = Enum.Parse<EventTypeId>(Event.EventType, true)
                    });
                }
                catch (ArgumentException ae)
                {
                    ViewBag.ValidationErrorMessage = ae.Message;
                    Event.AllEventTypes = _eventService.GetAllEventTypes();
                    return View(Event);
                }
                catch (InvalidEventHappensTimeException ioe)
                {
                    ViewBag.ValidationErrorMessage = ioe.Message;
                    Event.AllEventTypes = _eventService.GetAllEventTypes();
                    return View(Event);
                }

                return RedirectToAction("Index");
            }

            return View(Event);
        }

        public IActionResult AddOrUpdate(int? id)
        {

            Event = new EventInfoViewModel();
            Event.AllEventTypes = _eventService.GetAllEventTypes();

            if (id == null)
            {
                // Add
                var creationDate = DateTime.Now;
                Event.DateAdded = creationDate;
                Event.DateHappens = creationDate;
                Event.EventType = EventTypeId.Conference.ToString("G");
            }
            else
            {
                // Edit
                var eventToEdit = _eventService.GetById(id.Value);
                if (eventToEdit == null) return NotFound();

                Event.Id = eventToEdit.Id;
                Event.DateAdded = eventToEdit.DateAdded;
                Event.DateHappens = eventToEdit.DateHappens;
                Event.Description = eventToEdit.Description;
                Event.EventType = eventToEdit.EventTypeId.ToString("G");
                Event.Location = eventToEdit.Location;
                Event.MaxGuestsCount = eventToEdit.MaxGuestsCount;
                Event.Name = eventToEdit.Name;
            }

            return View(Event);
        }

        public IActionResult ManageGuests(int? id)
        {

            Event = new EventInfoViewModel();
            Event.AllEventTypes = _eventService.GetAllEventTypes();

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                // Edit
                var eventToEdit = _eventService.GetById(id.Value);
                if (eventToEdit == null) return NotFound();

                Event.Id = eventToEdit.Id;
                Event.DateAdded = eventToEdit.DateAdded;
                Event.DateHappens = eventToEdit.DateHappens;
                Event.Description = eventToEdit.Description;
                Event.EventType = eventToEdit.EventTypeId.ToString("G");
                Event.Location = eventToEdit.Location;
                Event.MaxGuestsCount = eventToEdit.MaxGuestsCount;
                Event.Name = eventToEdit.Name;
                Event.ListOfGuests = eventToEdit.ListOfGuests.Select(g => new GuestInfoViewModel
                {
                    Id = g.Id,
                    FirstName = g.FirstName,
                    LastName = g.LastName,
                    Patronymic = g.Patronymic,
                    Email = g.Email,
                    AssociatedEvent = Event,
                    Comment = g.Comment,
                });
            }

            return View(Event);
        }

        public IActionResult Archive(int id)
        {
            var eventToArchive = _eventService.GetById(id);
            if (eventToArchive == null) return NotFound();

            _eventService.ArchiveEvent(eventToArchive);

            return RedirectToAction("Index");
        }
    }
}
