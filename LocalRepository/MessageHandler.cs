using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalRepository
{
    public class MessageHandler
    {
        static List<CoreMessage> messages = new List<CoreMessage>();

        public void AddStudentData(CoreMessage msg)
        {
            messages.Add(msg);
        }
        public List<CoreMessage> QueryStudents()
        {
            return messages;
        }
    }
}
