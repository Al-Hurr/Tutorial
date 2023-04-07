using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using Tutorial.Word;
using Interval = System.ValueTuple<int, int>;

namespace Tutorial
{
    class Program
    {
        public static void Main(string[] args)
        {
            var singleLinkedList = new SingleLinkedList<int>();

            // adding
            singleLinkedList.Add(1);
            singleLinkedList.Add(2);
            singleLinkedList.Add(3);
            singleLinkedList.Add(2);
            singleLinkedList.Add(4);

            foreach (var value in singleLinkedList)
            {
                Console.Write($"{value} ");
            }

            // replacing
            singleLinkedList.Replace(1, 5);
            singleLinkedList.Replace(3, 6);
            singleLinkedList.Replace(4, 9);

            // joinig
            var singleLinkedList2 = new SingleLinkedList<int>
            {
                11,
                12,
                13
            };
            singleLinkedList.JoinWith(singleLinkedList2);

            //Simple.Start();
            ThreadPoolTutor.Run();
            //Example.Start();
            //WarZone.Run();


            //School21_Task_01.Run();

            //string str1 = "sunday";
            //string str2 = "saturday";

            //LevenshteinDistance.GetLevenshteinDistance(str1, str2);

            //Console.ReadLine();

            Console.WriteLine("End of main method");
        }
    }
    public class BaseClass
    {
        public virtual void DoWork()
        {
            Console.WriteLine("BaseClass.DoWork()");
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void DoWork()
        {
            Console.WriteLine("DerivedClass.DoWork()");
        }
    }
}
