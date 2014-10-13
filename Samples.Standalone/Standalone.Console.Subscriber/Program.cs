using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standalone.Console.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                    Initialize Console
            */
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("**********************************");
            System.Console.WriteLine("BUS SUBSCRIBER");
            System.Console.WriteLine("**********************************");
            System.Console.ForegroundColor = ConsoleColor.White;
            /*
                    Initialize Publisher Bus
            */
            var bus = CreateBus();

            System.Console.WriteLine("Waiting for available messages ... [CTRL+C to quit]");

            while (true)
            {
                var line = System.Console.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("THIS IS THE SUBSCRIBER!!!");
                    System.Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Create a Subscriber bus
        /// </summary>
        /// <returns></returns>
        private static IBus CreateBus()
        {
            /// initialize a new configuration
            var configuration = new BusConfiguration();
            /// set the transport mechanism
            configuration.UseTransport<MsmqTransport>();
            /// set the persistence mechanism
            configuration.UsePersistence<InMemoryPersistence>();
            /// here we specify the InProcess endpoint to listen to
            /// can be only one per process (See Service Bus pattern by Fowler)
            configuration.EndpointName("StandaloneQueue");

            var bus = Bus.Create(configuration);
            /// a Subscriber MUST be start before using it
            return bus.Start();
        }
    }
}
