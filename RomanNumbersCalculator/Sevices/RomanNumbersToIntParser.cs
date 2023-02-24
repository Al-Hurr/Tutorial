using RomanNumbersCalculator.Dictionaries;
using System.Text.RegularExpressions;

namespace RomanNumbersCalculator.Sevices
{
    internal class RomanNumbersToIntParser
    {
        private const string _strRegex = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        private readonly Regex _regex;

        public RomanNumbersToIntParser()
        {
            _regex = new Regex(_strRegex);
        }

        public int Parse(string romanNumber)
        {
            if (!Validate(romanNumber))
            {
                throw new ArgumentException($"Incorrect Roman numeral format. {romanNumber}");
            }

            int result = 0;

            for (int i = 0; i < romanNumber.Length - 1; i++)
            {
                int currentNumber = RomanNumbers.BasicRomanNumbers[romanNumber[i]];
                int nextNumber = RomanNumbers.BasicRomanNumbers[romanNumber[i + 1]];

                if (currentNumber < nextNumber)
                {
                    result -= currentNumber;
                }
                else
                {
                    result += currentNumber;
                }
            }

            return result += RomanNumbers.BasicRomanNumbers[romanNumber[^1]];
        }

        public bool Validate(string str)
        {
            return !string.IsNullOrEmpty(str) && _regex.IsMatch(str);
        }
    }
}
