using EventData.DataContracts;
using EventData.Models;
using EventManagerWeb.Models.Events;
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
                    EventType = result.EventType.ToString("G"),
                    GuestsCount = result.GuestsCount,
                    Location = result.Location,
                    MaxGuestsCount = result.MaxGuestsCount,
                    Name = result.Name
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

                var added = _eventService.AddNewEvent(new Event()
                {
                    Name = Event.Name,
                    Description = Event.Description,
                    DateAdded = DateTime.Now,
                    DateHappens = Event.DateHappens,
                    GuestsCount = Event.GuestsCount,
                    Location = Event.Location,
                    MaxGuestsCount = Event.MaxGuestsCount,
                    EventType = Enum.Parse<EventType>(Event.EventType)
                });

                return RedirectToAction("Index");
            }

            return View(Event);
        }

        public IActionResult AddOrUpdate(int? id)
        {

            Event = new EventInfoViewModel();

            if (id == null)
            {
                // Add
                var creationDate = DateTime.Now;
                Event.DateAdded = creationDate;
                Event.DateHappens = creationDate;
                Event.EventType = EventType.Conference.ToString("G");
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
                Event.EventType = eventToEdit.EventType.ToString("G");
                Event.GuestsCount = eventToEdit.GuestsCount;
                Event.Location = eventToEdit.Location;
                Event.MaxGuestsCount = eventToEdit.MaxGuestsCount;
                Event.Name = eventToEdit.Name;
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
