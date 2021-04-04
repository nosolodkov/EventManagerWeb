using EventData.DataContracts;
using EventManagerWeb.Models.Guests;
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

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
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
                    Comment = result.Comment
                })
            };

            return View(model);
        }
    }
}
