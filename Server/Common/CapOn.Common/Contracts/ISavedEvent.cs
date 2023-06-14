using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOn.Common.Contracts
{
    public interface ISavedEvent
    {
        Guid EntityId { get; set; }
        int? Version { get; set; }
        string? EventType { get; set; }
        string? Payload { get; set; }
        DateTime TimeCreated { get; set; }
    }
}
