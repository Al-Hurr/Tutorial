using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tutorial
{
    class ThreadPoolTutor
    {
        public static void Run()
        {
            using (var mutex = new Mutex(false, "oreilly.com OneAtATimeDemo"))
            {
                // Wait a few seconds if contended, in case another instance
                // of the program is still in the process of shutting down.

                if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
                {
                    Console.WriteLine("Another app instance is running. Bye!");
                    return;
                }

                RunProgram();
            }
        }

        static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }
    }

    class ForNullRefException
    {
        public string Prop { get; set; }
    }
}
