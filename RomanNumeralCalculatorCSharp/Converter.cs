using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralCalculatorCSharp
{
    public class Converter
    {
        public enum CalcFunction //Our calculator's operations.
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public string FullFunction(string firstNumeral, string secondNumeral, CalcFunction operation) 
        {
            string finalAnswer = ConvertNumberstoRomanNumerals(Calculate(operation, firstNumeral, secondNumeral));
            return finalAnswer;
        }

        public int ConvertSingleChars(char p)//Converts the Roman Numerals into numbers on the elementary level--that is, when the Roman numeral is a single digit long.
        {
            switch (p)
            {
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
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

        public int ConvertMulitpleChars(String EntireNumeral)//This algorithm computes Roman Numerals that are longer than one digit.
        {
            int primaryCharacter;
            int followingCharacter;
            long Answer = 0;

            for (int characterIndex = 0; characterIndex <= EntireNumeral.Length - 1; characterIndex++)
            {
                primaryCharacter = ConvertSingleChars(EntireNumeral[characterIndex]);
                if (characterIndex == EntireNumeral.Length - 1)
                {
                    Answer = Answer + primaryCharacter;
                    return (int)Answer;
                }
                followingCharacter = ConvertSingleChars(EntireNumeral[characterIndex + 1]);
                if (primaryCharacter < followingCharacter)
                {
                    Answer = Answer - primaryCharacter;
                }
                else
                {
                    Answer = primaryCharacter + Answer;
                }
            }
            return (int)Answer;
        }

        public int Calculate(CalcFunction calcFunction, String FirstNumber, String SecondNumber)//Will take in the two numerals and the specified math operation to return an answer as an integer.
        {
            int answer;
            switch (calcFunction) { 
                case CalcFunction.Add: 
                    return answer = (ConvertMulitpleChars(FirstNumber) + ConvertMulitpleChars(SecondNumber));
                case CalcFunction.Subtract:
                    return answer = (ConvertMulitpleChars(FirstNumber) - ConvertMulitpleChars(SecondNumber));
                case CalcFunction.Multiply:
                    return answer = (ConvertMulitpleChars(FirstNumber) * ConvertMulitpleChars(SecondNumber));
                case CalcFunction.Divide:
                    return answer = (ConvertMulitpleChars(FirstNumber) / ConvertMulitpleChars(SecondNumber));
                default:
                    return 0;
            }
        }

        public string ConvertNumberstoRomanNumerals(int x)//Converts the integer (x) taken from Calculate and converts it back into Roman Numerals. 
        {
            switch (x)//Converts x into a single digit Roman Numeral if it can.
            {
                case 1:
                    return "I";
                case 5:
                    return "V";
                case 10:
                    return "X";
                case 50:
                    return "L";
                case 100:
                    return "C";
                case 500:
                    return "D";
                case 1000:
                    return "M";
                default:
                    break;
            }

            switch (x.ToString().Length)//Takes the integer from Calculate and converts it into a string and measures the string to determine how many digits are in the number, so that it can be passed through the four following functions and converted one digit at a time. 
            {
                case 1:
                    return OneDigit(x);
                case 2:
                    return TwoDigit(x);
                case 3:
                    return ThreeDigit(x);
                case 4:
                    return FourDigit(x);
                default:
                    return "Your imput cannot be computed.";
            }
        }

        public string FourDigit(int x)
        {
            string Answer = "";
            int dividend = 0;
            for (int i = 0; i <= (x - 1000); i = i + 1000)
            {
                Answer = Answer + "M";
                dividend++;   
            }
		    return Answer + ConvertNumberstoRomanNumerals(x - (dividend * 1000));
        }
   
        public string ThreeDigit(int x)
        {
            string Answer = "";
            int dividend = 0;
            if (x >= 400 && x <= 499)
            {
                Answer = Answer + "CD" + ConvertNumberstoRomanNumerals(x - 400);
                return Answer;
            }
            else if (x >= 900 && x <= 999)
            {
                Answer = Answer + "CM" + ConvertNumberstoRomanNumerals(x - 900);
                return Answer;
            }
            else if (x < 500)
            {
                for (int i = 0; i <= (x - 100); i = i + 100)
                {
                    Answer = Answer + "C";
                    dividend++;
                }
                return Answer + ConvertNumberstoRomanNumerals(x - (dividend * 100));
            }
            else if (x > 500)
            {
                Answer = Answer + "D";
                for (int i = 0; i <= (x - 600); i = i + 100)
                {
                    Answer = Answer + "C";
                    dividend++;
                }
                return Answer + ConvertNumberstoRomanNumerals(x - (dividend * 100) - 500);
            }
            else return "0";
        }

        public string TwoDigit(int x)
        {
            string Answer = "";
            int dividend = 0;
            if (x >= 40 && x <= 49)
            {
                return Answer = Answer + "XL" + ConvertNumberstoRomanNumerals(x - 40);

            }
            else if (x >= 90 && x <= 99)
            {
                Answer = Answer + "XC" + ConvertNumberstoRomanNumerals(x - 90);
                return Answer;
            }
            else if (x < 50)
            {
                for (int i = 0; i <= (x - 10); i = i + 10)
                {
                    Answer = Answer + "X";
                    dividend++;
                }
                return Answer + ConvertNumberstoRomanNumerals(x - (dividend * 10));
            }
            else if (x > 50)
            {
                Answer = Answer + "L";
                for (int i = 0; i <= (x - 60); i = i + 10)
                {
                    Answer = Answer + "X";
                    dividend++;
                }
                return Answer + ConvertNumberstoRomanNumerals(x - (dividend * 10) - 50);
            }
            else return "0";
        }

        public string OneDigit(int x)
        {
            string Answer = "";
            if (x == 4)
            {
                return "IV";
            }
            else if (x == 9)
            {
                return "IX";
            }
            else if (x < 5)
            {
                for (int i = 0; i <= (x - 1); i++)
                {
                    Answer = Answer + "I";
                }
                return Answer;
            }
            else if (x > 5)
            {
                Answer = Answer + "V";
                for (int i = 0; i <= (x - 6); i++)
                {
                    Answer = Answer + "I";
                }
                return Answer;
            }
            else return "0";
        }
    }
}
