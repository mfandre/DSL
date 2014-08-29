using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSL_CAP1.StateMachine
{
    public class CommandChannel
    {
        private Action<string> channel;
        public CommandChannel(Action<string> channel)
        {
            this.channel = channel;
        }

        public void send(string code)
        {
            this.channel(code);
        }
    }
}
