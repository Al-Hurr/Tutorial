using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class School21_Task_01
    {
        static double loanAmmount;
        static double totalDeptBalance;
        static double annualPercentageRate;
        static int numberOfMonthsOfTheLoan;
        static int daysPerYear = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 : 365;
        static DateTime dateTimeFlag = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        public static void Run()
        {
            while (true)
            {
                string writedInfo = Console.ReadLine();
                Console.WriteLine();
                if (string.IsNullOrEmpty(writedInfo) || string.IsNullOrWhiteSpace(writedInfo))
                {
                    Console.WriteLine("Something went wrong. Check your input and retry.");
                    continue;
                }
                string[] splittedInfo = writedInfo.Trim().Split(' ');
                if (splittedInfo.Length != 3)
                {
                    Console.WriteLine("Something went wrong. Check your input and retry.");
                    continue;
                }

                try
                {
                    loanAmmount = Convert.ToDouble(splittedInfo[0]);
                    annualPercentageRate = Convert.ToDouble(splittedInfo[1]);
                    numberOfMonthsOfTheLoan = Convert.ToInt32(splittedInfo[2]);
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Check your input and retry.");
                    continue;
                }

                totalDeptBalance = loanAmmount;
                GetScheduleOfUpcomingPayments();

                Console.ReadLine();
                break;
            }
        }

        private static void GetScheduleOfUpcomingPayments()
        {
            double interestRateOnTheLoanPerMonth = GetInterestRateOnTheLoanPerMonth();
            double totalMonthlyPayment = GetTotalMonthlyPayment(interestRateOnTheLoanPerMonth, numberOfMonthsOfTheLoan);
            int daysOfThePeriod;
            double monthlyPaymentInterest;
            double principalDebt;

            for (int i = 0; i < numberOfMonthsOfTheLoan; i++)
            {
                // уточнить
                daysOfThePeriod = DateTime.DaysInMonth(dateTimeFlag.Year, dateTimeFlag.Month);
                monthlyPaymentInterest = GetMonthlyPaymentInterest(daysOfThePeriod);
                principalDebt = totalMonthlyPayment - monthlyPaymentInterest;
                totalDeptBalance = totalDeptBalance - principalDebt;
                if (i == numberOfMonthsOfTheLoan - 1 && totalDeptBalance < 0)
                {
                    //loanAmmount = loanAmmount + Math.Abs(totalDeptBalance);
                    //int monthTemp = numberOfMonthsOfTheLoan + 1;
                    //totalMonthlyPayment = GetTotalMonthlyPayment(interestRateOnTheLoanPerMonth, monthTemp);
                    //monthlyPaymentInterest = GetMonthlyPaymentInterest(daysOfThePeriod);
                    //principalDebt = totalMonthlyPayment - monthlyPaymentInterest;
                    //totalDeptBalance = totalDeptBalance - principalDebt;
                }
                Console.WriteLine($"{i + 1}\t{dateTimeFlag:dd-MM-yyyy}\t{PrintDouble(totalMonthlyPayment)}\t{PrintDouble(principalDebt)}\t{PrintDouble(monthlyPaymentInterest)}\t{PrintDouble(totalDeptBalance)}");
                dateTimeFlag = dateTimeFlag.AddMonths(1);
            }
        }

        static string PrintDouble(double number)
        {
            return $"{Math.Round(number, 2, MidpointRounding.AwayFromZero):N2}";
        }

        static double GetInterestRateOnTheLoanPerMonth()
        {
            return annualPercentageRate / 12 / 100;
        }

        static double GetTotalMonthlyPayment(double interestRateOnTheLoanPerMonth, int numberOfMonthsOfTheLoan)
        {
            return (loanAmmount * interestRateOnTheLoanPerMonth * Math.Pow(1 + interestRateOnTheLoanPerMonth, numberOfMonthsOfTheLoan))
            / (Math.Pow(1 + interestRateOnTheLoanPerMonth, numberOfMonthsOfTheLoan) - 1);
        }

        static double GetMonthlyPaymentInterest(int daysOfThePeriod)
        {
            return (totalDeptBalance * annualPercentageRate * daysOfThePeriod) / (100 * daysPerYear);
        }
    }
}
