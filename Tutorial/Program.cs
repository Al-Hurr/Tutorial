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
        static void Main(string[] args)
        {
            string str1 = "sunday";
            string str2 = "saturday";

            LevenshteinDistance.GetLevenshteinDistance(str1, str2);

            WarZone.Run();
            Console.ReadLine();
        }
    }
}
