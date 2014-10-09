
namespace BusSamples.Client
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, UsingTransport<MsmqTransport>
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
