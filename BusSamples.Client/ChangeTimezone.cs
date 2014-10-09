using BusSamples.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSamples.Client
{
    public class ChangeTimezone : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press ENTER to send a Message, CTRL+C to quit");

            while (Console.ReadLine() != null)
            {
                var personId = Guid.NewGuid();
                var timezoneId = Guid.NewGuid();

                Bus.Send("BusSamples.Server", new PersonTimezoneChanged {PersonId = personId, TimezoneId = timezoneId});

                Console.WriteLine("Person Timezone Changed!");
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
