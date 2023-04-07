using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Programm
    {
        private static async Task Mainn(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // synch

            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");

            //Egg eggs = FryEggs(2);
            //Console.WriteLine("eggs are ready");

            //Bacon bacon = FryBacon(3);
            //Console.WriteLine("bacon is ready");

            //Toast toast = ToastBread(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");

            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //Console.WriteLine("Breakfast is ready!");

            //asynch 1

            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");

            //Egg eggs = await FryEggsAsync(2);
            //Console.WriteLine("eggs are ready");

            //Bacon bacon = await FryBaconAsync(3);
            //Console.WriteLine("bacon is ready");

            //Toast toast = await ToastBreadAsync(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");

            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            //Console.WriteLine("Breakfast is ready!");

            //asynch 1

            //Coffee cup = PourCoffee();
            //Console.WriteLine("Coffee is ready");

            //// таски выполняются, не ожидая друг друга
            //Task<Egg> eggsTask = FryEggsAsync(2);
            //Task<Bacon> baconTask = FryBaconAsync(3);
            //Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            //Console.WriteLine("Toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("Oj is ready");

            //Egg eggs = await eggsTask;
            //Console.WriteLine("Eggs are ready");
            //Bacon bacon = await baconTask;
            //Console.WriteLine("Bacon is ready");

            //asynch 3

            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            // таски выполняются, не ожидая друг друга
            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

            // храним задачи, которые выполняются одновременно
            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

            while (breakfastTasks.Count > 0)
            {
                // берем задачу, которая выполнилась первым, позже удаляем ее из списка
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }

                await finishedTask;
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("Oj is ready");

            Console.WriteLine("Breakfast is ready!");

            stopwatch.Stop();

            Console.ReadLine();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int v)
        {
            var toast = await ToastBreadAsync(v);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }
    }
}