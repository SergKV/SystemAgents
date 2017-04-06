using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CoreService;
using Shared;
using Shared.Delegates;
using AgentComServices;

namespace CoreLogic
{
    public class LogicHandler
    {
        private List<CoreMessage> messages = new List<CoreMessage>();
        private MessageInformer frontEndInformer;
        private ServiceManager sManager;
  
        MSMQCommunication MSMQcom = new MSMQCommunication();
        CoreMessage message;

        public List<CoreMessage> Messages
        {
            get { return messages; }
            set { messages = value; }
        }


        public LogicHandler(MessageInformer frontEndInformer)
        {
            this.frontEndInformer = frontEndInformer; //used to inform the FrontEnd about the update
            /*
            Uri[] urls = new Uri[2];
            urls[0] = new Uri("http://localhost:8080/AgentService/");
            urls[1] = new Uri("net.tcp://localhost:8090/CoreService/");

            sManager = new ServiceManager(new MessageInformer(NewMessageReceived), urls);
            sManager.Start();*/

            MSMQcom.Start(@".\private$\DoJo3");
            //StartReceiving();
            Task.Factory.StartNew(StartReceiving);
        }

        private void StartReceiving()
        {
            while (true)
            {
                message = MSMQcom.Receive();
                Console.WriteLine(String.Format("Received message from \"{0}\" at \"{1}\"\r\n\t{2}",
                 message.Source, message.Date.ToShortTimeString(), message.Data));
            }
        }

        public void Stop()
        {
            sManager.Stop();
        }

        /// <summary>
        /// Receives the data form the service and can process the data (not done yet because no complex logic required)
        /// </summary>
        /// <param name="message"></param>
        private void NewMessageReceived(CoreMessage message)
        {
            messages.Add(message); //store message in list for further processing
            frontEndInformer(message); //send info to FrontEnd(GUI)
        }
    }
}
