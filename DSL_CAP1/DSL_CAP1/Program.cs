using DSL_CAP1.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSL_CAP1
{
    class Program
    {
        static void Main(string[] args)
        {
            MissGrantController();

            Console.In.Read();
        }

        private static void MissGrantController()
        {
            

            CommandChannel channel = new CommandChannel(a => Console.WriteLine("Action: " + a));
            MissGrantMachine builder = new MissGrantMachine(channel);
            bool done = false;
            while (!done)
            {
                Console.WriteLine("State: " + builder.CurrentState);
                Console.Write("> ");
                var cmd = Console.ReadLine();
                builder.Handle(cmd);
            }
        }
    }
}
