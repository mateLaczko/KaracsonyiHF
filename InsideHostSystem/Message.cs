using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideHostSystem
{
    public class Message
    {
        public Member From { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool Seen { get; set; }

        public Message(Member from, DateTime date, string content)
        {
            From = from;
            Date = date;
            Content = content;
        }
    }
}
