using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1.StateMachine
{
    public class Controller
    {
        private State currentState;
        private StateMachine machine;
        private CommandChannel commandsChannel;

        public Controller(StateMachine machine, CommandChannel commandChannel)
        {
            this.machine = machine;
            this.commandsChannel = commandChannel;
            this.currentState = machine.getStart();
        }

        public State getCurrentState()
        {
            return currentState;
        }

        public CommandChannel getCommandChannel()
        {
            return commandsChannel;
        }

        public void handle(string eventCode)
        {
            if (currentState.hasTransition(eventCode))
            {
                transitionTo(currentState.targetState(eventCode));
            }
            else if (machine.isResetEvent(eventCode))
            {
                transitionTo(machine.getStart());
            }
        }

        private void transitionTo(State target)
        {
            currentState = target;
            currentState.executeActions(commandsChannel);
        }
    }
}
