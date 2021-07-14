using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tutorial
{
    public class LoopDetector
    {
        static LoopDetector()
        {
            Node = new object();
        }
        public static object Node = new object();
    }
    public class Numbers
    {
        public int a, b;
        public Numbers(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }

    class Program
    {

        static void Add(object numbers)
        {
            if (numbers is Numbers)
            {
                Numbers nums = (Numbers)numbers;
                Console.WriteLine($"{nums.a} + {nums.b} = {nums.a + nums.b}");
                Thread.Sleep(5000);
                Console.WriteLine("Complete");
            }
        }

        static void Main(string[] args)
        {
            Controller(6, new int[] { 1, 2, 3, 2, 1, 0, 0, 0, 0 });
            Console.ReadLine();
        }

        public static void Controller(int studentsCount, int[] messageCountById)
        {
            List<Model> students = new List<Model>();
            List<string> response = new List<string>();
             
            for (int i = 0; i < messageCountById.Length; i++)
            {
                var student = new Model
                {
                    Id = i + 1,
                    MessageCount = messageCountById[i]
                };

                if (student.Id == 1)
                    student.ReceivedNotification = true;

                students.Add(student);
            }

            foreach(var student in students)
            {
                var result = student.SendMessage(students);
                response.AddRange(result.Item1);
            }

            if(students.Any(x => !x.ReceivedNotification))
            {
                Console.WriteLine("-1");
            }
            else
            {
                foreach (var resp in response)
                {
                    Console.WriteLine(resp);
                }
            }

        }

        //public static int getLoopSize(LoopDetector.Node startNode)
        //{
        //    HashSet<LoopDetector.Node> nodesDic = new HashSet<LoopDetector.Node>();
        //    var currentNode = startNode;
        //    while (!nodesDic.Contains(currentNode))
        //    {
        //        nodesDic.Add(currentNode);
        //        currentNode = currentNode.next;
        //    }
        //    var headNode = currentNode;
        //    currentNode = currentNode.next;
        //    int count = 1;
        //    while (currentNode != headNode)
        //    {
        //        count++;
        //        currentNode = currentNode.next;
        //    }
        //    return count;
        //}

        public static bool IsValidWalk(string[] walk)
        {
            if (walk.Length != 10)
                return false;

            int[] walkNumbs = new int[10];

            for (int i = 0; i < 10; i++)
            {
                switch (walk[i].ToLower())
                {
                    case "n":
                        walkNumbs[i] = 1;
                        break;
                    case "s":
                        walkNumbs[i] = -1;
                        break;
                    case "e":
                        walkNumbs[i] = 2;
                        break;
                    case "w":
                        walkNumbs[i] = -2;
                        break;
                    default:
                        break;
                }
            }

            if (walkNumbs.Sum() == 0)
                return true;

            return false;
        }


        public static bool ValidParentheses(string input)
        {
            Console.WriteLine(input);

            if (string.IsNullOrEmpty(input))
                return true;

            if (input.Contains('(') && input.IndexOf('(') < input.IndexOf(')'))
            {
                int index;
                while (input.Contains(')') || input.Contains('('))
                {
                    index = input.IndexOf('(');
                    for (int i = index + 1; i < input.Length; i++)
                    {
                        if (input[i] == ')')
                        {
                            input = input.Remove(i, 1);
                            break;
                        }
                    }
                    input = input.Remove(index, 1);
                    if ((!input.Contains('(') && input.Contains(')')) || (!input.Contains(')') && input.Contains('(')))
                        return false;
                }
                return true;
            }

            // Your code here
            return false;
        }

        public static string GetReadableTime(int seconds)
        {
            //true code
            // return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);

            //my code
            string hours = "00";
            string minutes = "00";
            string secondsString = "00";
            int minutesInt;

            if (seconds < 60)
            {
                secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
                return $"{hours}:{minutes}:{secondsString}";
            }

            if (seconds >= 60 && seconds < 3600)
            {
                minutesInt = seconds / 60;
                minutes = minutesInt < 10 ? "0" + minutesInt.ToString() : minutesInt.ToString();
                seconds = seconds % 60;

                secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
                return $"{hours}:{minutes}:{secondsString}";
            }

            int hoursInt = seconds / 3600;
            hours = hoursInt < 10 ? "0" + hoursInt.ToString() : hoursInt.ToString();

            minutesInt = (seconds / 60) % 60;
            minutes = minutesInt < 10 ? "0" + minutesInt.ToString() : minutesInt.ToString();

            seconds = seconds % 60;
            secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

            return $"{hours}:{minutes}:{secondsString}";
        }

        public static int FindEvenIndex(int[] arr)
        {
            if (arr.Length == 0)
                return 0;

            for (int j = 0; j < arr.Length - 1; j++)
            {
                int leftSide = 0;
                int rightSide = 0;
                for (int left = 0; left < j; left++)
                {
                    leftSide += arr[left];
                }
                for (int right = j + 1; right < arr.Length; right++)
                {
                    rightSide += arr[right];
                }
                if (leftSide == rightSide)
                    return j;
            }

            //for (int i = 0; i < arr.Length -1; i++)
            //{
            //    Console.WriteLine($"Number : {arr[i]} Take sum: {arr.Take(i).Sum()} Skip sum {arr.Skip(i + 1).Sum()}");
            //    if (arr.Take(i).Sum() == arr.Skip(i + 1).Sum())
            //        return i;
            //}
            return -1;
        }

        public static int DuplicateCount(string str)
        {
            return str.ToLower().Distinct().Where(x => str.ToLower().Where(y => y == x).Count() > 1).Count();
        }

        public static string Likes(string[] name)
        {
            string result;
            switch (name.Length)
            {
                case 0:
                    result = "no one likes this";
                    break;
                case 1:
                    result = $"{name[0]} likes this";
                    break;
                case 2:
                    result = $"{name[0]} and {name[1]} like this";
                    break;
                case 3:
                    result = $"{name[0]}, {name[1]} and {name[2]} like this";
                    break;
                default:
                    result = $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
                    break;
            }
            return result;
        }

        public static int Find(int[] integers)
        {
            return integers.Take(3).Where(x => x % 2 == 0).Count() >= 2 ? integers.FirstOrDefault(x => x % 2 != 0) : integers.FirstOrDefault(x => x % 2 == 0);
        }

        public static string Disemvowel(string str)
        {
            //code from CODEWARS
            str = string.Concat(str.Where(ch => !"aeiouAEIOU".Contains(ch)));

            //my code
            //if (string.IsNullOrEmpty(str))
            //{
            //    return "";
            //}
            //var vowels = new string[] { "a", "e", "i", "o", "u" };

            //foreach (var vowel in vowels)
            //{
            //    if (str.ToLower().Contains(vowel))
            //    {
            //        var vowelsCount = str.Where(x => x.ToString().ToLower() == vowel).Count();
            //        while (str.ToLower().Contains(vowel))
            //        {
            //            str = str.Remove(str.ToLower().IndexOf(vowel), 1);
            //        }
            //    }
            //}
            return str;
        }

        public static string Maskify(string cc)
        {
            //my code
            //if (cc.Length > 4)
            //{
            //    string forHashes = cc.Substring(0, cc.Length - 4);
            //    foreach(var forHash in forHashes)
            //    {
            //        forHashes = forHashes.Replace(forHash, '#');
            //    }
            //    return string.Concat(forHashes, string.Concat(cc.Skip(cc.Length - 4)));
            //}
            //else
            //{
            //    return cc;
            //}

            //code from CODEWARS
            string str = cc.Substring(cc.Length - 4);

            str = str.PadLeft(cc.Length, '#');

            return cc.Length > 4 ? cc.Substring(cc.Length - 4).PadLeft(cc.Length, '#') : cc;
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            //if (b.Length == 0 || a.Length == 0)
            //    return a;

            //List<int> result = new List<int>();
            //bool order = false;
            //for (int i = 0; i < a.Length; i++)
            //{
            //    order = true;
            //    for(int j = 0; j < b.Length; j++)
            //    {
            //        if(a[i] == b[j])
            //        {
            //            order = false;
            //        }
            //    }
            //    if(order)
            //        result.Add(a[i]);
            //}

            //code frome codewars
            return a.Where(x => !b.Contains(x)).ToArray();
            // Your brilliant solution goes here
            // It's possible to pass random tests in about a second ;)
        }
    }
}
