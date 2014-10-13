using NServiceBus;
using Standalone.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Standalone.Console.Publisher
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
            System.Console.WriteLine("BUS PUBLISHER");
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
                var standaloneMessage = StandaloneMessage.Create(content);
                bus.Send(standaloneMessage);
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
            if (!MessageQueue.Exists(@".\private$\StandaloneQueue"))
            {
                MessageQueue.Create(@".\private$\StandaloneQueue", true);
            }

            /// create a new bus instance (disposable)
            var bus = Bus.CreateSendOnly(configuration);
            return bus;
        }
    }
}
