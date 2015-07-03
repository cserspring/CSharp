namespace ServiceBusRelayClient
{
    using System;
    using System.ServiceModel;
    using Microsoft.ServiceBus;
    using ServiceBusRelayServer;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var cf = new ChannelFactory<IProblemSolverChannel>(
                new NetTcpRelayBinding(),
                new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "[NAMESPACE]", "solver")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider =
                    TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "[KEY]")
            });

            using (var ch = cf.CreateChannel())
            {
                Console.WriteLine(ch.AddNumbers(4, 5));
            }
        }
    }
}
