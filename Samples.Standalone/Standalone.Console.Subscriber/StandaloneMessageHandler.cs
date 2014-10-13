using NServiceBus;
using Standalone.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standalone.Console.Subscriber
{
    public class StandaloneMessageHandler : IHandleMessages<StandaloneMessage>
    {

        public void Handle(StandaloneMessage message)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Message received");

            System.Console.WriteLine("Id: {0} - Content: {1}", message.Id, message.BodyContent);
        }
    }
}
