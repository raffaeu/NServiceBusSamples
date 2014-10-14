using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using System.Messaging;
using Mvc.Messages;

namespace Mvc.Console.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                    Initialize Console
            */
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("**********************************");
            System.Console.WriteLine("BUS PUBLISHER FOR MVC");
            System.Console.WriteLine("**********************************");
            System.Console.ForegroundColor = ConsoleColor.White;

            /*
                    Initialize Publisher Bus
            */
            var bus = CreateBus();

            System.Console.WriteLine("Please Enter a string ... [CTRL+C to quit]");

            /*
                    Create Messages and send
                    Endpoint is configured inside app.config for flexibility
            */
            while (true)
            {
                var content = System.Console.ReadLine();
                var mvcMessage = MvcMessage.Create(content);
                bus.Send(mvcMessage);
            }
        }

        /// <summary>
        /// Create a sender bus
        /// </summary>
        /// <returns></returns>
        private static ISendOnlyBus CreateBus()
        {
            /// initialize a new configuration
            var configuration = new BusConfiguration();
            /// set the transport mechanism
            configuration.UseTransport<MsmqTransport>();
            /// set the persistence mechanism
            configuration.UsePersistence<InMemoryPersistence>();

            /*
                Standalone process MUST manually configure MSMQ
            */
            if (!MessageQueue.Exists(@".\private$\MvcSubscriber"))
            {
                MessageQueue.Create(@".\private$\MvcSubscriber", true);
            }

            /// create a new bus instance (disposable)
            var bus = Bus.CreateSendOnly(configuration);
            return bus;
        }
    }
}
