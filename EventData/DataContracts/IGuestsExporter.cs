using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IGuestsExporter
    {
        object Export(List<Guest> guests, string destination);
    }
}
