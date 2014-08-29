using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1.StateMachine
{
    public class AbstractEvent
    {
        private string name, code;

        public AbstractEvent(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        public string getCode() { return code; }
        public string getName() { return name; }
    }

    public class Command : AbstractEvent
    {
        public Command(string name, string code)
            : base(name, code)
        { }
    }

    public class Event : AbstractEvent
    {
        public Event(string name, string code)
            : base(name, code)
        { }
    }
}
