using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoJo2Agent.SR_AgentAdapter;

namespace DoJo2Agent
{
    class Program
    {
        private static bool run = true;
        static void Main(string[] args)
        {          
            Console.WriteLine("DoJo2Agent started");
            
            MessageTransmissionServiceClient client = new MessageTransmissionServiceClient();
            client.TransmitMessageCompleted += Client_TransmitMessageCompleted;


            //client.Submit(new CoreMessage() { Source = "DummyGuiAgent", Date = DateTime.Now, Data = "SOME DEMO DATA" });
            //client.TransmitMessageAsync(new CoreMessage() {Data="someData", Date=DateTime.Now, Source="DoJo2 agent" });

            while (run)
            {
                Console.WriteLine("Waiting the data");
            }
        }

        private static void Client_TransmitMessageCompleted(object sender, TransmitMessageCompletedEventArgs e)
        {
            run = false ;
            Console.WriteLine("Data sent to agent!!!");
        }
    }
}
