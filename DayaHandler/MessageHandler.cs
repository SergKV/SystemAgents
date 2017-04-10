using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaHandler
{
    public class MessageHandler
    {
        static List<CoreMessage> messageList = new List<CoreMessage>();

        public void AddMessage(CoreMessage msg)
        {
            messageList.Add(msg);
        }
        public List<CoreMessage> QueryList()
        {
            return messageList;
        }
    }
}
