using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralCalculatorCSharp {
    public class Converter {
        private Dictionary<CalcFunction, Func<int, int, int>> operationMap = new Dictionary<CalcFunction, Func<int, int, int>>() {
            {CalcFunction.Add, (x, y) => {return x + y;}}, 
            {CalcFunction.Subtract, (x, y) => {return x - y;}}, 
            {CalcFunction.Multiply, (x, y) => {return x * y;}}, 
            {CalcFunction.Divide, (x, y) => {return x / y;}}, 
        };


        public string FullFunction(string FirstNumber, string SecondNumber, CalcFunction calcFunction) {
            return ConvertNumberstoRomanNumerals(Calculate(calcFunction, FirstNumber, SecondNumber));
        }

        /// <summary>
        /// Converts the Roman Numerals into numbers on the elementary level--that is, 
        /// when the Roman numeral is a single digit long.
        /// </summary>
        private Dictionary<char, int> ConvertSingleChars = new Dictionary<char, int>() {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        //This algorithm computes Roman Numerals that are longer than one digit.
        public int ConvertMulitpleChars(String EntireNumeral) {
            int primaryCharacter;
            int followingCharacter;
            long Answer = 0;

            for (int characterIndex = 0; characterIndex <= EntireNumeral.Length - 1; characterIndex++) {
                primaryCharacter = ConvertSingleChars[EntireNumeral[characterIndex]];
                if (characterIndex == EntireNumeral.Length - 1) {
                    Answer = Answer + primaryCharacter;
                    return (int)Answer;
                }
                followingCharacter = ConvertSingleChars[EntireNumeral[characterIndex + 1]];
                if (primaryCharacter < followingCharacter) {
                    Answer = Answer - primaryCharacter;
                } else {
                    Answer = primaryCharacter + Answer;
                }
            }
            return (int)Answer;
        }
        //Will take in the two numerals and the specified math operation to return an answer as an integer.
        public int Calculate(CalcFunction calcFunction, String FirstNumber, String SecondNumber) {
            return operationMap[calcFunction].Invoke(ConvertMulitpleChars(FirstNumber), ConvertMulitpleChars(SecondNumber));
        }
        //Converts the integer (x) taken from Calculate and converts it back into Roman Numerals. 
        public string ConvertNumberstoRomanNumerals(int x) {
            return ConvertNumberstoRomanNumerals(x.ToString());
        }

        public string ConvertNumberstoRomanNumerals(string x) {
            var answer = "";
            string currentDigit = x[0].ToString();
            if (Int32.Parse(x) > 3999) { return "Input can not be computed"; }
            var digitMap = numeralDigitMap[x.Length];
            var digitInt = Int32.Parse(currentDigit);
            if (digitMap.ContainsKey(currentDigit)) {
                answer += digitMap[currentDigit];
            } else if (digitInt < 5){
                for (int i = 0; i <= (digitInt - 1); i ++) {
                    answer += digitMap["1"];
                }
            } else if (digitInt > 5){
                answer += digitMap["5"];
                for (int i = 0; i <= (digitInt - 6); i ++) {
                    answer += digitMap["1"];
                }
            }
            if (x.Length == 1) {
                return answer;
            }
            return answer + ConvertNumberstoRomanNumerals(x.Substring(1));
        }

        private Dictionary<int, Dictionary<string, string>> numeralDigitMap = new Dictionary<int, Dictionary<string, string>>() {
            {1, new Dictionary<string, string>(){
                {"1", "I"},
                {"4", "IV"},
                {"5", "V"},
                {"9", "IX"},
            }},
            {2, new Dictionary<string, string>(){
                {"1", "X"},
                {"4", "XL"},
                {"5", "L"},
                {"9", "XC"},
            }},
            {3, new Dictionary<string, string>(){
                {"1", "C"},
                {"4", "CD"},
                {"5", "D"},
                {"9", "CM"},
            }},
            {4, new Dictionary<string, string>(){
                {"1", "M"}
            }}
        };



        //Our calculator's operations.
        public enum CalcFunction {
            Add,
            Subtract,
            Multiply,
            Divide
        }
    }
}
