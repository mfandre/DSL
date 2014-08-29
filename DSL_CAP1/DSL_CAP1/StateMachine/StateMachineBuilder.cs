using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1.StateMachine
{
    public abstract class StateMachineBuilder
    {
        private CommandChannel channel;
        private Controller controller;
        private StateMachine machine;

        public StateMachineBuilder(CommandChannel commandChannel)
        {
            this.channel = commandChannel;
            this.machine = CreateMachine();
            this.controller = new Controller(machine, commandChannel);
        }

        protected abstract StateMachine CreateMachine();

        public void Handle(string eventCode)
        {
            controller.handle(eventCode);
        }

        public List<Transition> CurrentTransitions
        {
            get { return this.controller.getCurrentState().getTransitions(); }
        }

        public string CurrentState
        {
            get { return this.controller.getCurrentState().getName(); }
        }
    }
}
