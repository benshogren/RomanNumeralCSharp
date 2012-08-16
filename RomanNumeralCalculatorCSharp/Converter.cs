﻿using System;
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

        public string ConvertNumberstoRomanNumerals(int x)
        {
            switch (x)
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
            if (x.ToString().Length == 1)
            {
                return OneDigit(x);
            }
            else if (x.ToString().Length == 2)
            {
                return TwoDigit(x);
            }
            else if (x.ToString().Length == 3)
            {
                return ThreeDigit(x);
            }
            else return FourDigit(x);
        }

        public string FourDigit(int x)
        {
            string Answer = "";
            int y;
            switch (x.ToString()[0])
            {
                case '1':
                    Answer = Answer + "M";
                    y = x - 1000;
                    break;
                case '2':
                    Answer = Answer + "MM";
                    y = x - 2000;
                    break;
                case '3':
                    Answer = Answer + "MMM";
                    y = x - 3000;
                    break;
                default:
                    y = 0;
                    break;
            }
            Answer = Answer + ConvertNumberstoRomanNumerals(y);
            return Answer;
        }

        public string ThreeDigit(int x)
        {
            string Answer = "";
            int y;
            switch (x.ToString()[0])
            {
                case '1':
                    Answer = Answer + "C";
                    y = x - 100;
                    break;
                case '2':
                    Answer = Answer + "CC";
                    y = x - 200;
                    break;
                case '3':
                    Answer = Answer + "CCC";
                    y = x - 300;
                    break;
                case '4':
                    Answer = Answer + "CD";
                    y = x - 400;
                    break;
                case '5':
                    Answer = Answer + "D";
                    y = x - 500;
                    break;
                case '6':
                    Answer = Answer + "DC";
                    y = x - 600;
                    break;
                case '7':
                    Answer = Answer + "DCC";
                    y = x - 700;
                    break;
                case '8':
                    Answer = Answer + "DCCC";
                    y = x - 800;
                    break;
                case '9':
                    Answer = Answer + "CM";
                    y = x - 900;
                    break;
                default:
                    y = 0;
                    break;
            }
            Answer = Answer + ConvertNumberstoRomanNumerals(y);
            return Answer;
        }

        public string TwoDigit(int x)
        {
            string Answer = "";
            int y;
            switch (x.ToString()[0]) 
            {
                case '1':
                    Answer = Answer + "X";
                    y = x - 10;
                    break;
                case '2':
                    Answer = Answer + "XX";
                    y = x - 20;
                    break;
                case '3':
                    Answer = Answer + "XXX";
                    y = x - 30;
                    break;
                case '4':
                    Answer = Answer + "XL";
                    y = x - 40;
                    break;
                case '5':
                    Answer = Answer + "L";
                    y = x - 50;
                    break;
                case '6':
                    Answer = Answer + "LX";
                    y = x - 60;
                    break;
                case '7':
                    Answer = Answer + "LXX";
                    y = x - 70;
                    break;
                case '8':
                    Answer = Answer + "LXXX";
                    y = x - 80;
                    break;
                case '9':
                    Answer = Answer + "XC";
                    y = x - 90;
                    break;
                default:
                    y = 0;
                    break;
            }
            Answer = Answer + ConvertNumberstoRomanNumerals(y);
            return Answer; 
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

            for (int characterIndex = 0; characterIndex <= WholeNumeral.Length - 1; characterIndex++)
            {
                primaryCharacter = ConvertSingleChars(WholeNumeral[characterIndex]);
                if (characterIndex == WholeNumeral.Length - 1)
                {
                    answer = answer + primaryCharacter;
                    return (int)answer;
                }
                followingCharacter = ConvertSingleChars(WholeNumeral[characterIndex + 1]);
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
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
