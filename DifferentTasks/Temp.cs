
using System.Collections.Generic;
using System.Threading;
using System;

namespace DifferentTasks
{
    #region  Task 1
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var linesCount = Int32.Parse(Console.ReadLine());

    //        int[] results = new int[linesCount];

    //        for (int i = 0; i < linesCount; i++)
    //        {
    //            var numbers = Console.ReadLine().Trim().Split(" ");
    //            var num1 = Int32.Parse(numbers[0]);
    //            var num2 = Int32.Parse(numbers[1]);
    //            results[i] = num1 + num2;
    //        }

    //        foreach (var item in results)
    //        {
    //            Console.WriteLine(item);
    //        }

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Task 2
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var linesCount = Int32.Parse(Console.ReadLine());
    //        int[] amountsArr = new int[linesCount];

    //        for (int i = 0; i < linesCount; i++)
    //        {
    //            var itemsCount = Int32.Parse(Console.ReadLine());

    //            int[] itemsArr = new int[itemsCount];
    //            var itemsStrArr = Console.ReadLine().Trim().Split(" ");

    //            if (itemsCount == 1)
    //            {
    //                amountsArr[i] = Int32.Parse(itemsStrArr[0]);
    //                continue;
    //            }

    //            if (itemsCount == 2)
    //            {
    //                amountsArr[i] = Int32.Parse(itemsStrArr[0]) + Int32.Parse(itemsStrArr[1]);
    //                continue;
    //            }

    //            for (int j = 0; j < itemsCount; j++)
    //            {
    //                itemsArr[j] = Int32.Parse(itemsStrArr[j]);
    //            }

    //            var groupItems = itemsArr.GroupBy<int, int>(x => x);

    //            int ammount = 0;
    //            foreach (var items in groupItems)
    //            {
    //                int count = items.Count();
    //                ammount += (count - count / 3) * items.Key;
    //            }

    //            amountsArr[i] = ammount;
    //        }

    //        foreach (var ammount in amountsArr)
    //        {
    //            Console.WriteLine(ammount);
    //        }

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Task 3
    //class Program
    //{
    //    struct Command
    //    {
    //        public int FirstDev;
    //        public int SecondDev;

    //        public override string ToString()
    //        {
    //            return $"{FirstDev} {SecondDev}";
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        var dataKitCount = Int32.Parse(Console.ReadLine());

    //        List<Command[]> commandsList = new List<Command[]>(dataKitCount);

    //        for (int i = 0; i < dataKitCount; i++)
    //        {
    //            var devsCount = Int32.Parse(Console.ReadLine());

    //            int[] devsArr = new int[devsCount];
    //            var devsStrArr = Console.ReadLine().Trim().Split(" ");

    //            if (devsCount == 2)
    //            {
    //                commandsList.Add(new Command[] { new Command { FirstDev = 1, SecondDev = 2 } });
    //                continue;
    //            }

    //            for (int j = 0; j < devsCount; j++)
    //            {
    //                devsArr[j] = Int32.Parse(devsStrArr[j]);
    //            }

    //            int commandCount = devsCount / 2;
    //            Command[] devsCommand = new Command[commandCount];
    //            int filledCommandIdx = 0;
    //            for (int firstDevIdx = 0; firstDevIdx < devsCount - 1; firstDevIdx++)
    //            {
    //                int firstDev = devsArr[firstDevIdx];
    //                if (firstDev == -1) continue;
    //                devsArr[firstDevIdx] = -1;
    //                int secondDevIdxTmp = -1;
    //                int diff = -1;

    //                for (int secondDevIdx = firstDevIdx + 1; secondDevIdx < devsCount; secondDevIdx++)
    //                {
    //                    int secondDev = devsArr[secondDevIdx];
    //                    if (secondDev == -1) continue;
    //                    int diffTmp = Math.Abs(firstDev - secondDev);
    //                    if (diffTmp < diff || diff == -1)
    //                    {
    //                        diff = diffTmp;
    //                        secondDevIdxTmp = secondDevIdx;
    //                    }
    //                }

    //                if (secondDevIdxTmp == -1 || diff == -1) continue;

    //                devsCommand[filledCommandIdx] = new Command { FirstDev = firstDevIdx + 1, SecondDev = secondDevIdxTmp + 1 };
    //                filledCommandIdx++;
    //                devsArr[secondDevIdxTmp] = -1;
    //            }

    //            commandsList.Add(devsCommand);
    //        }

    //        foreach (var command in commandsList)
    //        {
    //            foreach (var devsPair in command)
    //            {
    //                Console.WriteLine(devsPair);
    //            }

    //            Console.WriteLine();
    //        }

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region Task 4
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var dataKitCount = Int32.Parse(Console.ReadLine().Trim());
    //        Console.WriteLine();
    //        HashSet<int[,]> matrixes = new HashSet<int[,]>(dataKitCount);

    //        for (int idx1 = 0; idx1 < dataKitCount; idx1++)
    //        {
    //            Console.ReadLine();
    //            var matrixSizeStr = Console.ReadLine().Trim().Split(" ");

    //            int rowsCount = Int32.Parse(matrixSizeStr[0]);
    //            int columnsCount = Int32.Parse(matrixSizeStr[1]);

    //            if (columnsCount == 1)
    //            {
    //                int[,] pseudoMatrix = new int[rowsCount, 1];

    //                for (int idx2 = 0; idx2 < rowsCount; idx2++)
    //                {
    //                    pseudoMatrix[idx2, 0] = Int32.Parse(Console.ReadLine());
    //                }

    //                int a = Int32.Parse(Console.ReadLine());
    //                var b = Console.ReadLine().Trim().Split(" ");

    //                for (int i = 0; i < pseudoMatrix.GetLength(0); i++)
    //                {
    //                    for (int j = 0; j < pseudoMatrix.GetLength(0) - 1; j++)
    //                    {
    //                        if (pseudoMatrix[j + 1, 0] < pseudoMatrix[j, 0])
    //                        {
    //                            int tmp = pseudoMatrix[j, 0];
    //                            pseudoMatrix[j, 0] = pseudoMatrix[j + 1, 0];
    //                            pseudoMatrix[j + 1, 0] = tmp;
    //                        }
    //                    }
    //                }

    //                matrixes.Add(pseudoMatrix);
    //                Console.WriteLine();
    //                continue;
    //            }

    //            int[,] matrix = new int[rowsCount, columnsCount];

    //            for (int idx2 = 0; idx2 < rowsCount; idx2++)
    //            {
    //                var rowStr = Console.ReadLine().Trim().Split(" ");
    //                for (int idx3 = 0; idx3 < columnsCount; idx3++)
    //                {
    //                    matrix[idx2, idx3] = Int32.Parse(rowStr[idx3]);
    //                }
    //            }

    //            var clickCount = Int32.Parse(Console.ReadLine());
    //            var clicksStr = Console.ReadLine().Trim().Split(" ");

    //            int[] clickedColumns = new int[clickCount];
    //            for (int idx3 = 0; idx3 < clickCount; idx3++)
    //            {
    //                clickedColumns[idx3] = Int32.Parse(clicksStr[idx3]) - 1;
    //            }

    //            for (int idx3 = 0; idx3 < clickCount; idx3++)
    //            {
    //                int clickedColumn = clickedColumns[idx3];
    //                if (idx3 != 0 && clickedColumns[idx3] == clickedColumns[idx3] - 1)
    //                {
    //                    continue;
    //                }

    //                for (int i = 0; i < matrix.GetLength(0); i++)
    //                {
    //                    for (int j = 0; j < matrix.GetLength(0) - 1; j++)
    //                    {
    //                        if (matrix[j + 1, clickedColumn] < matrix[j, clickedColumn])
    //                        {
    //                            for (int k = 0; k < matrix.GetLength(1); k++)
    //                            {
    //                                int tmp = matrix[j, k];
    //                                matrix[j, k] = matrix[j + 1, k];
    //                                matrix[j + 1, k] = tmp;
    //                            }
    //                        }
    //                    }
    //                }
    //            }

    //            matrixes.Add(matrix);
    //            Console.WriteLine();
    //        }

    //        foreach (var matrix in matrixes)
    //        {
    //            for (int i = 0; i < matrix.GetLength(0); i++)
    //            {
    //                for (int j = 0; j < matrix.GetLength(1); j++)
    //                {
    //                    Console.Write($"{matrix[i, j]} ");
    //                }

    //                Console.WriteLine();
    //            }

    //            Console.WriteLine();
    //        }

    //        Console.ReadLine();
    //    }
    //}
    #endregion

    #region ля адри ма хаза
    //class MyTask
    //{
    //    public int ComingTime { get; set; }
    //    public int ProcessingTime { get; set; }

    //    public MyTask(int comingTime, int processingTime)
    //    {
    //        ComingTime = comingTime;
    //        ProcessingTime = processingTime;
    //    }
    //}

    //class MyProcessor
    //{
    //    public static int TotalProcessTime = 0;
    //    public int Consumption { get; set; }
    //    public bool IsBusy { get; set; }

    //    public MyProcessor(int consumption)
    //    {
    //        Consumption = consumption;
    //        IsBusy = false;
    //    }

    //    public void Process(int workTime)
    //    {
    //        int processTime = Consumption * workTime;
    //        IsBusy = true;
    //        Console.WriteLine($"Wait for {workTime} seconds in {Consumption}");
    //        Thread.Sleep(TimeSpan.FromSeconds(workTime));

    //        Interlocked.Add(ref TotalProcessTime, processTime);
    //        IsBusy = false;
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        List<Thread> threads = new List<Thread>();
    //        var threadsAndTasks = Console.ReadLine().Trim().Split(" ");

    //        List<MyProcessor> myProcessors = new List<MyProcessor>(Int32.Parse(threadsAndTasks[0]));
    //        Queue<MyTask> myTasks = new Queue<MyTask>(Int32.Parse(threadsAndTasks[1]));

    //        var processProps = Console.ReadLine().Trim().Split(" ");

    //        foreach (var item in processProps)
    //        {
    //            myProcessors.Add(new MyProcessor(Int32.Parse(item)));
    //        }

    //        for (int i = 0; i < Int32.Parse(threadsAndTasks[1]); i++)
    //        {
    //            var taskProps = Console.ReadLine().Trim().Split(" ");
    //            myTasks.Enqueue(new MyTask(Int32.Parse(taskProps[0]), Int32.Parse(taskProps[1])));
    //        }
    //        int time = 1;
    //        while (myTasks.Count() > 0)
    //        {
    //            var task = myTasks.Peek();
    //            if (task.ComingTime != time)
    //            {
    //                time++;
    //                Thread.Sleep(TimeSpan.FromSeconds(1));
    //                continue;
    //            }

    //            myTasks.Dequeue();

    //            var processor = myProcessors.Where(x => !x.IsBusy).OrderBy(x => x.Consumption).FirstOrDefault();
    //            if (processor == null)
    //            {
    //                time++;
    //                Thread.Sleep(TimeSpan.FromSeconds(1));
    //                continue;
    //            }

    //            Console.WriteLine($"Star for Task # {task.ComingTime}");
    //            var thread = new Thread(() => processor.Process(task.ProcessingTime));
    //            threads.Add(thread);
    //            thread.Start();

    //            Thread.Sleep(TimeSpan.FromSeconds(1));
    //            time++;
    //        }

    //        threads.ForEach(x => x.Join());
    //        Console.WriteLine(MyProcessor.TotalProcessTime);
    //        //Console.ReadLine();
    //    }
    //}
    #endregion
}
