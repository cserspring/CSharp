namespace ServiceBusTopicSubscription
{
    using System;
    using System.Threading;
    using Microsoft.Azure;
    using Microsoft.ServiceBus;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static void Main(string[] args)
        {
            string topicName = "TestTopic";
            TopicDescription td = new TopicDescription(topicName);
            td.MaxSizeInMegabytes = 5120;
            td.EnablePartitioning = true;
            td.DefaultMessageTimeToLive = new TimeSpan(12, 0, 0);
            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.TopicExists(topicName))
            {
                namespaceManager.CreateTopic(td);
            }

            if (!namespaceManager.SubscriptionExists(topicName, "AllMessages"))
            {
                namespaceManager.CreateSubscription(topicName, "AllMessages");
            }

            // The most flexible type of filter supported by subscriptions is the SqlFilter class, 
            // which implements a subset of SQL92. SQL filters operate on the properties of the messages 
            // that are published to the topic.
            if (!namespaceManager.SubscriptionExists(topicName, "HighMessages"))
            {
                SqlFilter highMessagesFilter = new SqlFilter("MessageNumber > 21");
                namespaceManager.CreateSubscription(topicName, "HighMessages", highMessagesFilter);
            }

            if (!namespaceManager.SubscriptionExists(topicName, "LowMessages"))
            {
                SqlFilter lowMessagesFilter = new SqlFilter("MessageNumber < 21");
                namespaceManager.CreateSubscription(topicName, "LowMessages", lowMessagesFilter);
            }

            TopicClient topicClient = TopicClient.CreateFromConnectionString(connectionString, topicName);
            for (int i = 0; i < 50; i++)
            {
                BrokeredMessage message = new BrokeredMessage("Test message " + i);
                message.Properties["MessageNumber"] = i;
                topicClient.Send(message);
            }

            Thread.Sleep(1000);

            // Below is the receiver
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionString,
                topicName, "HighMessages");
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            subscriptionClient.OnMessage((message) =>
            {
                try
                {
                    Console.WriteLine("\n**High Messages**");
                    Console.WriteLine("Body: " + message.GetBody<string>());
                    Console.WriteLine("MessageId:" + message.MessageId);
                    Console.WriteLine("Message Number: " + message.Properties["MessageNumber"]);
                    message.Complete();
                }
                catch (Exception)
                {
                    message.Abandon();
                }
            }, options);

            Console.ReadLine();
        }
    }
}
