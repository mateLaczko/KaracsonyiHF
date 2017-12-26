using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideHostSystem
{
    public interface IMember
    {
         string Name { get; }
         string Pass { get; }
         bool LogedIn { get; }
         List<Member> Contacts { get; }
         List<Member> Requests { get; }
         Stack<Message> Messages { get; }
    }
}
