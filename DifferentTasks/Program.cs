using RomanNumbersCalculator;
using System;
using System.IO;
using System.Text;

namespace DifferentTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("(L + X )/ X");
            Console.WriteLine(result);
            // "(MMMDCCXXIV - MMCCXXIX) * II"

            // 1 - 
            //StringReader
            //var calculator = new RomanNumbersToIntParser();
            //var result = calculator.ParseRomanNumberToInt("MMCCXXIX");

            Console.ReadLine();
        }
    }
}