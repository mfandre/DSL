using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1.StateMachine
{
    public class StateMachine
    {
        private State start;
        private List<Event> resetEvents = new List<Event>();

        public StateMachine(State start)
        {
            this.start = start;
        }

        public List<State> getStates()
        {
            List<State> result = new List<State>();
            collectStates(result, start);
            return result;
        }

        private void collectStates(List<State> result, State start)
        {
            if (result.Contains(start)) return;
            result.Add(start);
            foreach(State next in start.getAllTargets()){
                collectStates(result, next);
            }
        }

        public void addResetEvents(Event[] events){
            foreach (Event e in events)
            {
                resetEvents.Add(e);
            }
        }

        private void addResetEvent_byAddingTransitions(Event e)
        {
            foreach (State s in getStates())
            {
                if (!s.hasTransition(e.getCode()))
                    s.addTransition(e, start);
            }
        }

        public State getStart()
        {
            return start;
        }

        public Boolean isResetEvent(string eventCode)
        {
            return resetEventsCodes().Contains(eventCode);
        }

        private List<string> resetEventsCodes()
        {
            List<string> result = new List<string>();
            foreach (Event e in resetEvents) result.Add(e.getCode());

            return result;
        }

    }
}
