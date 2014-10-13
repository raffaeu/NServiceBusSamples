using BusSamples.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSamples.Server
{
    public class PersonTimezoneChangedHandler : IHandleMessages<PersonTimezoneChanged>
    {
        public IBus Bus { get; set; }



        public void Handle(PersonTimezoneChanged message)
        {
            Console.WriteLine("Person {0} has Timezone {1}", message.PersonId, message.TimezoneId);
        }
    }
}
