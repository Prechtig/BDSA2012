using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace WCFSimpleChat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class ChatService : IChatService
    {
        static StringBuilder notes = new StringBuilder();
        
        public String PostNote(String name, String note)
        {
            notes.AppendFormat("{0}: {1}\n", name, note);
            Console.WriteLine("{0}: {1}", name, note);
            return notes.ToString();
        }
    }
}
