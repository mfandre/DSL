using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1.StateMachine
{
    class MissGrantMachine : StateMachineBuilder
    {
        private CommandChannel channel;

        public MissGrantMachine(CommandChannel channel) : base (channel)
        {
        }

        protected override StateMachine CreateMachine()
        {
            Event doorClosed = new Event("doorClosed", "D1CL");
            Event drawerOpened = new Event("drawerOpened", "D2OP");
            Event lightOn = new Event("lightOn", "L1ON");
            Event doorOpened = new Event("doorOpened", "D1OP");
            Event panleClosed = new Event("panleClosed", "PNCL");

            Command unlockPanelCmd = new Command("unlockPanel", "PNUL");
            Command lockPanelCmd = new Command("lockPanel", "PNLK");
            Command lockDoorCmd = new Command("lockDoor", "D1LK");
            Command unlockDoorCmd = new Command("unlockDoor", "D1UL");

            State idle = new State("idle");
            State activeState = new State("active");
            State waitingForLightState = new State("waitingForLight");
            State waitingForDrawerState = new State("waitingForDrawer");
            State unlockedPanelState = new State("unlockedPanel");

            StateMachine machine = new StateMachine(idle);

            idle.addTransition(doorClosed, activeState);
            idle.addAction(unlockDoorCmd);
            idle.addAction(lockPanelCmd);

            activeState.addTransition(drawerOpened, waitingForLightState);
            activeState.addTransition(lightOn, waitingForDrawerState);

            waitingForLightState.addTransition(lightOn, unlockedPanelState);

            waitingForDrawerState.addTransition(drawerOpened, unlockedPanelState);

            unlockedPanelState.addAction(unlockPanelCmd);
            unlockedPanelState.addAction(lockDoorCmd);
            unlockedPanelState.addTransition(panleClosed, idle);

            machine.addResetEvents(new Event[] { doorOpened });

            return machine;
        }
    }
}
