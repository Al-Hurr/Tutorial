//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Runtime.Remoting.Messaging;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Tutorial
//{
//    public delegate void MyMethod(string s);

//    public class WarZone
//    {
//        public string Name { get; set; }
//        //indexator
//        List<TestClass> al = new List<TestClass>();
//        TestClass this[int i]
//        {
//            get => al[i];
//            set => al.Insert(i, value);
//        }

//        public static void Run()
//        {
//            //AsyncBreakfast.Program.Main(null);

//            while (true)
//            {
//                Console.WriteLine("-----------------after main-----------------");
//                Thread.Sleep(3000);
//            }

//            WarZone[] warZones;

//            warZones = new WarZone[2]
//            {
//                new WarZone{Name = "1"},
//                new WarZone{Name = "2"}
//            };

//            warZones = warZones.Append(new WarZone { Name = "3" }).ToArray();
//            //warZones = wzs;

//            TestHttpClient();
//        }

//        private static void TestHttpClient()
//        {
//            var _client = new HttpClient(new HttpClientHandler() { CookieContainer = new CookieContainer() });
//            var data = new StringContent("{\"username\":\"ris-rtkrad\",\"password\":\"3A4p*Kc5V84G\"}", Encoding.UTF8, "application/json-patch+json");
//            var response = _client.PostAsync("http://91.144.142.145:5001/auth/", data).Result;
//            string resultContent = response.Content.ReadAsStringAsync().Result;
//        }

//        public class Printer
//        {
//            private object lockObj = new object();
//            public static void PrintNumbers(object obj)
//            {
//                int thrNumb = -1;
//                if (obj is Int32 number)
//                {
//                    thrNumb = number;
//                }
//                Console.WriteLine("Thread " + thrNumb);
//            }
//        }

//        public static void ThreadTestMethod()
//        {
//            Thread thr2 = new Thread(new ThreadStart(() =>
//            {
//                int count2 = 0;
//                while (count2 < 10)
//                {
//                    Console.WriteLine("Thread 2 " + Thread.CurrentThread.Name);
//                    Thread.Sleep(1000);
//                    count2++;
//                }
//                Console.WriteLine("End Thread 2");
//                Console.ReadLine();
//            }));
//            thr2.IsBackground = true; ;
//            thr2.Start();
//            int count = 0;
//            while (count < 5)
//            {
//                Console.WriteLine("Thread 1 " + Thread.CurrentThread.Name);
//                Thread.Sleep(1000);
//                count++;
//            }
//            Console.WriteLine("End Thread 1");
//        }

//        public static bool isMerge(string s, string part1, string part2)
//        {
//            if (s.Length == 0 && part1.Length == 0 && part2.Length == 0)
//            {
//                return true;
//            }
//            //List<char> letters = s.Where(x => !Char.IsDigit(x)).ToList();
//            List<char> letters = s.ToList();
//            if (letters.Count == 0)
//            {
//                return false;
//            }
//            StringBuilder sb = new StringBuilder();
//            List<char> part1Chars = new List<char>();
//            foreach (char letter in part1)
//            {
//                part1Chars.Add(letter);
//            }

//            List<char> part2Chars = new List<char>();
//            foreach (char letter in part2)
//            {
//                part2Chars.Add(letter);
//            }
//            int partsCount = part1Chars.Count() + part2Chars.Count();
//            for (int i = 0; i < letters.Count; i++)
//            {
//                char letter = letters[i];
//                bool isExiststPart1Letter = part1Chars.Exists(x => x == letter);
//                bool isExiststPart2Letter = part2Chars.Exists(x => x == letter);

//                if (!isExiststPart1Letter && !isExiststPart2Letter)
//                {
//                    continue;
//                }

//                if (isExiststPart1Letter && isExiststPart2Letter)
//                {
//                    part1Chars.Remove(letter);
//                }
//                else if (!isExiststPart1Letter && isExiststPart2Letter)
//                {
//                    part2Chars.Remove(letter);
//                }
//                else if (isExiststPart1Letter && !isExiststPart2Letter)
//                {
//                    part1Chars.Remove(letter);
//                }

//                sb.Append(letter);
//            }
//            string outLetter = new string(letters.ToArray());
//            bool isCountEquals = letters.Count() == partsCount;
//            if (outLetter == sb.ToString() && isCountEquals)
//            {
//                return true;
//            }

//            return false;
//        }

//        public static bool isMerge2(string s, string part1, string part2)
//        {
//            if (s.Length == 0 && part1.Length == 0 && part2.Length == 0)
//            {
//                return true;
//            }
//            //List<char> letters = s.Where(x => !Char.IsDigit(x)).ToList();
//            List<char> letters = s.ToList();
//            if (letters.Count == 0)
//            {
//                return false;
//            }
//            StringBuilder sb = new StringBuilder();
//            Stack<char> part1Chars = new Stack<char>();
//            for (int i = part1.Length - 1; i >= 0; i--)
//            {
//                part1Chars.Push(part1[i]);
//            }

//            Stack<char> part2Chars = new Stack<char>();
//            for (int i = part2.Length - 1; i >= 0; i--)
//            {
//                part2Chars.Push(part2[i]);
//            }
//            int partsCount = part1Chars.Count + part2Chars.Count;
//            for (int i = 0; i < letters.Count; i++)
//            {
//                char letter = letters[i];
//                bool isExiststPart1Letter = false;
//                bool isExiststPart2Letter = false;
//                if (part1Chars.Count != 0)
//                    isExiststPart1Letter = letter == part1Chars.Peek();
//                if (part2Chars.Count != 0)
//                    isExiststPart2Letter = letter == part2Chars.Peek();

//                if (!isExiststPart1Letter && !isExiststPart2Letter)
//                {
//                    continue;
//                }

//                if (isExiststPart1Letter && isExiststPart2Letter)
//                {
//                    int p1Eq = 0;
//                    int p2Eq = 0;
//                    int counter = i;
//                    foreach (var item in part1Chars)
//                    {
//                        if (item != letters[counter])
//                        {
//                            break;
//                        }
//                        p1Eq++;
//                        counter++;
//                    }
//                    counter = i;
//                    foreach (var item in part2Chars)
//                    {
//                        if (item != letters[counter])
//                        {
//                            break;
//                        }
//                        p2Eq++;
//                        counter++;
//                    }
//                    if (p1Eq > p2Eq)
//                    {
//                        part1Chars.Pop();
//                    }
//                    else
//                    {
//                        part2Chars.Pop();
//                    }
//                }
//                else if (!isExiststPart1Letter && isExiststPart2Letter)
//                {
//                    part2Chars.Pop();
//                }
//                else if (isExiststPart1Letter && !isExiststPart2Letter)
//                {
//                    part1Chars.Pop();
//                }

//                sb.Append(letter);
//            }
//            string outLetter = new string(letters.ToArray());
//            bool isCountEquals = letters.Count() == partsCount;
//            if (outLetter == sb.ToString() && isCountEquals)
//            {
//                return true;
//            }

//            return false;
//        }

//        /// <summary>
//        /// Counter. Press "SPACE" key to count.
//        /// </summary>
//        static void CounterMethod()
//        {
//            Console.Clear();
//            int count = 0;
//            while (true)
//            {
//                Console.WriteLine(count);
//                string key = Console.ReadKey().Key.ToString();
//                if (key == "Spacebar")
//                {
//                    count++;
//                    Console.Clear();
//                }
//            }
//        }

//        /// <summary>
//        /// Перегрузка бинарных, унарных операций (+,-,/,*, etc.)
//        /// </summary>
//        static void PeregruzkaBinarnyhOperaciy()
//        {
//            Point p1 = new Point(5, 4);
//            Point pRef = p1;
//            Point p2 = new Point(5, 4);

//            bool cond1 = p1.Equals(p2);
//            bool cond2 = p1.Equals(pRef);
//            bool cond3 = p1 == p2;
//            bool cond4 = p1 == pRef;

//            Point p3 = p1 * p2;
//            p1 *= p2;
//            //унарный
//            ++p2;
//        }

//        static void NullConditionTest(TestClass testClass1, TestClass testClass2)
//        {
//            if (testClass1?.Value > testClass2.Value)
//            {
//                Console.WriteLine("sdcsdcsd");
//            }
//        }

//        static void MethodForDelegate(string str)
//        {
//            Console.WriteLine(str);
//        }
//    }

//    public class TestClass
//    {
//        public delegate void MyDelegate(string str);
//        private static MyDelegate _md;
//        public int Value { get; set; }

//        public static void Reg(MyDelegate md)
//        {
//            _md += md;
//        }

//        public static void Go()
//        {
//            if (_md != null)
//            {
//                _md("Work");
//            }
//        }
//    }

//    public class Point
//    {
//        public static Point operator *(Point p1, Point p2) => new Point(p1.X * p2.X, p1.Y * p2.Y);
//        public static Point operator ++(Point p) => new Point(p.X + 1, p.Y + 1);

//        public Point() { }

//        public Point(int x, int y)
//        {
//            this.X = x;
//            this.Y = y;
//        }

//        public int X { get; set; }
//        public int Y { get; set; }
//    }

//    public struct Rec
//    {
//        public int W { get; set; }
//        public int H { get; set; }
//        public Rec(int w, int h) : this()
//        {
//            this.W = w;
//            this.H = h;
//        }
//        public void Draw()
//        {
//            for (int i = 0; i < H; i++)
//            {
//                for (int j = 0; j < W; j++)
//                {
//                    Console.Write("*");
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}
