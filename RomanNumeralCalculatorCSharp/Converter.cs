using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralCalculatorCSharp
{
    public class Converter
    {
        public enum CalcFunction{
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public int Calculate(CalcFunction calcFunction, String FirstNumber, String SecondNumber)
        {
            if (calcFunction == CalcFunction.Add)
            {
                int answer = (Convert(FirstNumber) + Convert(SecondNumber));
                return answer;
            }
            else if (calcFunction == CalcFunction.Subtract)
            {
                int answer = (Convert(FirstNumber) - Convert(SecondNumber));
                return answer;
            }
            else if (calcFunction == CalcFunction.Multiply)
            {
                int answer = (Convert(FirstNumber) * Convert(SecondNumber));
                return answer;
            }
            else if (calcFunction == CalcFunction.Divide) 
            {
                int answer = (Convert(FirstNumber) / Convert(SecondNumber));
                return answer;
            }
            else return 0; 
        }

        public int Convert(String WholeNumeral)
        {
            int primaryCharacter;
            int followingCharacter;
            long answer = 0;

            for (int numeralChar = 0; numeralChar <= WholeNumeral.Length - 1; numeralChar++)
            {
                primaryCharacter = ConvertSingleChars(WholeNumeral[numeralChar]);
                if (numeralChar == WholeNumeral.Length - 1)
                {
                    answer = answer + primaryCharacter;
                    return (int)answer;
                }
                followingCharacter = ConvertSingleChars(WholeNumeral[numeralChar + 1]);
                if (primaryCharacter < followingCharacter)
                {
                    answer = answer - primaryCharacter;
                }
                else
                {
                    answer = primaryCharacter + answer;
                }
            }
            return (int)answer;
        }
        public int ConvertSingleChars(char p)
        {
            switch (p) { 
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
