namespace ServiceBusRelayServer
{
    using System.ServiceModel;

    [ServiceContract(Namespace = "urn:ps")]
    public interface IProblemSolver
    {
        [OperationContract]
        int AddNumbers(int a, int b);
    }

    public interface IProblemSolverChannel : IProblemSolver, IClientChannel { }
}
