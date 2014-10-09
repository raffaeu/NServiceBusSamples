using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSamples.Messages
{
    public class PersonTimezoneChanged : IMessage
    {
        public Guid PersonId { get; set; }

        public Guid TimezoneId { get; set; }
    }
}
