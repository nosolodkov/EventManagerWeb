using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerWeb.Models.Guests
{
    public class GuestsViewModel
    {
        public IEnumerable<GuestInfoViewModel> Guests { get; set; }
    }
}
