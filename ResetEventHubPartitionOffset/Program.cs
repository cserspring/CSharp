namespace ResetEventHubPartitionOffset
{
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static void Main(string[] args)
        {
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString("[Event Hub Connection String]", "[Event Hub Name]");

            EventHubConsumerGroup group = eventHubClient.GetConsumerGroup("[Consumer Group Name]");
            string[] partitionIds = eventHubClient.GetRuntimeInformation().PartitionIds;
            foreach (var id in partitionIds)
            {
                var receiver = group.CreateReceiver(id, null);
                receiver.Receive();
            }
            
        }
    }
}
