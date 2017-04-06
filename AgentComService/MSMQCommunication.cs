using System;
using System.Messaging;
using Shared;
using Shared.Interfaces;

namespace AgentComServices
{
    public class MSMQCommunication
    {
        private string messageQueueName = @".\private$\SyCo";
        private MessageQueue messageQueue;

        public void Start()
        {
            CreateMSMQ();
            messageQueue = new MessageQueue(@"FormatName:direct=os:" + messageQueueName);
            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(CoreMessage) });
        }

        public void Start(string messageQueueName)
        {            
            messageQueue = new MessageQueue(@"FormatName:direct=os:" + messageQueueName);
            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(CoreMessage) });
        }
        

        public void Submit(CoreMessage message)
        {
            messageQueue.Send(message);
        }

        private void CreateMSMQ()
        {
            if (!MessageQueue.Exists(messageQueueName))
            {
                MessageQueue.Create(messageQueueName);
            }
        }

        public CoreMessage Receive()
        {
            return (CoreMessage)messageQueue.Receive().Body;
        }

    }
}
