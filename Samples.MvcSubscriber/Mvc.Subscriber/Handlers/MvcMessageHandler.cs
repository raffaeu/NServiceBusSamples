using Mvc.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Subscriber.Handlers
{
    public class MvcMessageHandler : IHandleMessages<MvcMessage>
    {
        public void Handle(MvcMessage message)
        {
            Console.WriteLine("Id: {0} and Message: {1}", message.Id, message.BodyContent);
        }
    }
}