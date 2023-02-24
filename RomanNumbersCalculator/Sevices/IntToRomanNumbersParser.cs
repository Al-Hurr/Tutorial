
using RomanNumbersCalculator.Dictionaries;
using System.Text;

namespace RomanNumbersCalculator.Sevices
{
    internal class IntToRomanNumbersParser
    {
        public string Parse(int number)
        {   
            if(number < 1 || number > 3999)
            {
                throw new Exception($"The result {number} cannot be parsed to Roman numeral");
            }

            string numberStr = number.ToString();
            StringBuilder sb = new StringBuilder();
            for (int i = numberStr.Length - 1; i >= 0; i--)
            {
                if (numberStr[i] == '0')
                    continue;

                int rank = numberStr.Length - 1 - i;

                sb.Insert(0, GetRomanNumber(Int32.Parse(numberStr[i].ToString()), rank));
            }

            return sb.ToString();
        }

        private string GetRomanNumber(int num, int rank)
        {
            switch(rank)
            {
                case 3:
                    return RomanNumbers.RomanNumbersDecimalRanks[num * 1000];
                case 2:                                             
                    return RomanNumbers.RomanNumbersDecimalRanks[num * 100];
                case 1:                                            
                    return RomanNumbers.RomanNumbersDecimalRanks[num * 10];
                case 0:
                    return RomanNumbers.RomanNumbersDecimalRanks[num];
                default:
                    return string.Empty;
            }
        }
    }
}
