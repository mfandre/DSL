using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1.StateMachine
{
    public class State
    {
        private string name;
        private List<Command> actions = new List<Command>();
        private Dictionary<String, Transition> transitions = new Dictionary<string, Transition>();

        public State(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public List<Transition> getTransitions()
        {
            return transitions.Values.ToList<Transition>();
        }

        public void addTransition(Event evt, State targetState)
        {
            if( null == targetState)
                return;
            transitions.Add(evt.getCode(), new Transition(this, evt, targetState));
        }

        public List<State> getAllTargets()
        {
            List<State> result = new List<State>();

            foreach(Transition t in transitions.Values){
                result.Add(t.getTarget());
            }

            return result;
        }

        public bool hasTransition(string eventCode)
        {
            return transitions.ContainsKey(eventCode);
        }

        public State targetState(string eventCode)
        {
            Transition t;
            transitions.TryGetValue(eventCode, out t);
            return t.getTarget();
        }

        public void executeActions(CommandChannel commandsChannel)
        {
            foreach (Command c in actions) commandsChannel.send(c.getCode());
        }

        public void addAction(Command action)
        {
            actions.Add(action);
        }
    }
}
