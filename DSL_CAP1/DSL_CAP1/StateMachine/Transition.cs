using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSL_CAP1.StateMachine
{
    public class Transition
    {
        private readonly State source, target;
        private readonly Event trigger;

        public Transition(State source, Event trigger, State target)
        {
            this.source = source;
            this.trigger = trigger;
            this.target = target;
        }

        public State getSource() { return source; }
        public State getTarget() { return target; }
        public Event getTrigger() { return trigger; }
        public String getEventCode() { return trigger.getCode(); }
    }
}
