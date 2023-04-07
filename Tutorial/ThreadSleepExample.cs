//using System;
//using System.Threading;

//namespace Tutorial
//{
//    public class Example
//    {
//        private static void Start()
//        {
//            // Interrupt a sleeping thread.
//            var sleepingThread = new Thread(Example.SleepIndefinitely);
//            sleepingThread.Name = "Sleeping";
//            sleepingThread.Start();
//            Console.WriteLine("dd");
//            Console.WriteLine("dd");
//            Console.WriteLine("dd");
//            Console.WriteLine("dd");
//            Console.WriteLine("dd");
//            Console.WriteLine("dd");
//            Console.WriteLine("dd");
//            Thread.Sleep(2000);
//            sleepingThread.Interrupt();

//            Thread.Sleep(1000);

//            sleepingThread = new Thread(Example.SleepIndefinitely);
//            sleepingThread.Name = "Sleeping2";
//            sleepingThread.Start();
//            Thread.Sleep(2000);
//            sleepingThread.Abort();
//        }

//        private static void SleepIndefinitely()
//        {
//            Console.WriteLine("Thread '{0}' about to sleep indefinitely.",
//                              Thread.CurrentThread.Name);
//            try
//            {
//                Thread.Sleep(Timeout.Infinite);
//            }
//            catch (ThreadInterruptedException)
//            {
//                Console.WriteLine("Thread '{0}' awoken.",
//                                  Thread.CurrentThread.Name);
//            }
//            catch (ThreadAbortException)
//            {
//                Console.WriteLine("Thread '{0}' aborted.",
//                                  Thread.CurrentThread.Name);
//            }
//            finally
//            {
//                Console.WriteLine("Thread '{0}' executing finally block.",
//                                  Thread.CurrentThread.Name);
//            }
//            Console.WriteLine("Thread '{0} finishing normal execution.",
//                              Thread.CurrentThread.Name);
//            Console.WriteLine();
//        }
//    }
//}
