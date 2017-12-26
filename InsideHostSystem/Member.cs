using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InsideHostSystem
{
    public class Member : IMember
    {
        public static List<Member> AllMembers { get; set; }

        public string Name { get; private set; }
        public string Pass { get; private set; }
        public bool LogedIn { get; set; }
        public List<Member> Contacts { get; set; }
        public List<Member> Requests { get; set; }
        public Stack<Message> Messages { get; set; } //Azért Stack mert mindig az utolsónak kapottat akarom az első helyen látni

        static Member()
        {
            AllMembers = new List<Member>();
        }
    
        public Member(string name, string pass)
        {
            Name = name;
            Pass = pass;
            Contacts = new List<Member>();
            Requests = new List<Member>();
            Messages = new Stack<Message>();
        }
    }
}
