namespace ServiceBusRelayServer
{
    using System;
    using System.ServiceModel;
    using Microsoft.ServiceBus;

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(ProblemSolver));

            sh.AddServiceEndpoint(
               typeof(IProblemSolver), new NetTcpBinding(),
               "net.tcp://localhost:9358/solver");
            
            sh.AddServiceEndpoint(
               typeof(IProblemSolver), new NetTcpRelayBinding(),
               ServiceBusEnvironment.CreateServiceUri("sb", "[NAMESPACE]", "solver"))
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "[KEY]")
                });

            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }
    }
}
