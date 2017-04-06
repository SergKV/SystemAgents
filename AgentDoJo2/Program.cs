using AgentDoJo2.SR_AgentAdapter;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace AgentDoJo2
{
    class Program
    {
        public static MessageTransmissionServiceClient com = new MessageTransmissionServiceClient();
        public static List<string>tmpData = new List<String>();
        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Tick;
            timer.Start();

            Logic log = new Logic();
            string input;
            Console.WriteLine("AGENT DOJO2 STARTED");          

            while(true)
            {
                Console.WriteLine("Please enter your family name:");                                
                input = Console.ReadLine();
                tmpData = log.LetterSelection(input);
            }
        }

        private static void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            if(tmpData.Count > 0)
            {                    
                foreach (var item in tmpData)
                {
                    com.TransmitMessageAsync(new CoreMessage() { Source = "DOJO2 AGENT", Date = DateTime.Now, Data = item });
                }
                tmpData.Clear();
            }
        }
    }
}
