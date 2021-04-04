using EventData.Models;
using System.Collections.Generic;

namespace EventData.DataContracts
{
    public interface IGuestsImporter
    {
        List<Guest> Import(string source, object format);
    }
}
