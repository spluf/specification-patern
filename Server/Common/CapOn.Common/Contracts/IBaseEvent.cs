using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapOn.Common.Contracts
{
    public interface IBaseEvent
    {
        int Version { get; }
        public string EventType { get; }
    }
}
