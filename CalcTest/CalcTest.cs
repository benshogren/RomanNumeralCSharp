using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RomanNumeralCalculatorCSharp;

namespace CalcTest
{
    [TestFixture]
    class CalcTests
    {
        [Test]
        public void TestI()
        {
            Converter c = new Converter();
            Assert.AreEqual(1, c.Convert("I"));
        }
        [Test]
        public void TestV()
        {
            Converter v = new Converter();
            Assert.AreEqual(5, v.Convert("V"));
        }
        [Test]
        public void TestX() 
        {
            Converter x = new Converter();
            Assert.AreEqual(10, x.Convert("X"));
        }
        [Test]
        public void TestL()
        {
            Converter l = new Converter();
            Assert.AreEqual(50, l.Convert("L"));
        }
        [Test]
        public void TestC()
        {
            Converter c = new Converter();
            Assert.AreEqual(100, c.Convert("C"));
        }
        [Test]
        public void TestM()
        {
            Converter m = new Converter();
            Assert.AreEqual(1000, m.Convert("M"));
        }
        [Test]
        public void TestIV()
        {
            Converter iv = new Converter();
            Assert.AreEqual(4, iv.Convert("IV"));
        }
        [Test]
        public void TestXIV()
        {
            Converter iv = new Converter();
            Assert.AreEqual(14, iv.Convert("XIV"));
        }
        [Test]
        public void TestAdd()
        {
            Converter a = new Converter();
            Assert.AreEqual(4, a.Calculate((Converter.CalcFunction.Add), ("III"),("I")));
        }
        [Test]
        public void TestSubtract()
        {
            Converter s = new Converter();
            Assert.AreEqual(2, s.Calculate((Converter.CalcFunction.Subtract), ("III"), ("I")));
        }
        [Test]
        public void TestMultiply()
        {
            Converter m = new Converter();
            Assert.AreEqual(10, m.Calculate((Converter.CalcFunction.Multiply), ("II"), ("V")));
        }
        [Test]
        public void TestDivide()
        {
            Converter d = new Converter();
            Assert.AreEqual(2, d.Calculate((Converter.CalcFunction.Divide), ("X"), ("V")));
        }
        [Test]
        public void TestSubtractNegativeResult()
        {
            Converter s = new Converter();
            Assert.AreEqual(-2, s.Calculate((Converter.CalcFunction.Subtract), ("IV"), ("VI")));
        }
        [Test]
        public void TestEveryNumeral()
        {
            Converter e = new Converter();
            Assert.AreEqual(1470, e.Calculate((Converter.CalcFunction.Add), ("MCDXLIII"), ("XXVII")));
        }
        [Test]
        public void TestConvertBackwardsI()
        {
            Converter c = new Converter();
            Assert.AreEqual("I", c.ConvertNumberstoRomanNumerals(1));
        }
        [Test]
        public void TestConvertBackwardsV()
        {
            Converter c = new Converter();
            Assert.AreEqual("V", c.ConvertNumberstoRomanNumerals(5));
        }
        [Test]
        public void TestConvertBackwardsD()
        {
            Converter c = new Converter();
            Assert.AreEqual("D", c.ConvertNumberstoRomanNumerals(500));
        }
        [Test]
        public void TestConvertComboBackwardsVI()
        {
            Converter c = new Converter();
            Assert.AreEqual("VI", c.ConvertNumberstoRomanNumerals(6));
        }
        [Test]
        public void TestConvertComboBackwardsIV()
        {
            Converter c = new Converter();
            Assert.AreEqual("IV", c.ConvertNumberstoRomanNumerals(4));
        }
        [Test]
        public void TestConvertComboBackwardsIII()
        {
            Converter c = new Converter();
            Assert.AreEqual("III", c.ConvertNumberstoRomanNumerals(3));
        }
        [Test]
        public void TestConvertComboBackwards40()
        {
            Converter c = new Converter();
            Assert.AreEqual("XL", c.ConvertNumberstoRomanNumerals(40));
        }
        [Test]
        public void TestConvertComboBackwards46()
        {
            Converter c = new Converter();
            Assert.AreEqual("XLVI", c.ConvertNumberstoRomanNumerals(46));
        }
        [Test]
        public void TestConvertComboBackwards89()
        {
            Converter c = new Converter();
            Assert.AreEqual("LXXXIX", c.ConvertNumberstoRomanNumerals(89));
        }
        [Test]
        public void TestConvertComboBackwards99()
        {
            Converter c = new Converter();
            Assert.AreEqual("XCIX", c.ConvertNumberstoRomanNumerals(99));
        }
        [Test]
        public void TestConvertComboBackwards12()
        {
            Converter c = new Converter();
            Assert.AreEqual("XII", c.ConvertNumberstoRomanNumerals(12));
        }
        [Test]
        public void TestConvertComboBackwards122()
        {
            Converter c = new Converter();
            Assert.AreEqual("CXXII", c.ConvertNumberstoRomanNumerals(122));
        }
        [Test]
        public void TestConvertComboBackwards387()
        {
            Converter c = new Converter();
            Assert.AreEqual("CCCLXXXVII", c.ConvertNumberstoRomanNumerals(387));
        }
        [Test]
        public void TestConvertComboBackwards999()
        {
            Converter c = new Converter();
            Assert.AreEqual("CMXCIX", c.ConvertNumberstoRomanNumerals(999));
        }
        [Test]
        public void TestConvertComboBackwards1012()
        {
            Converter c = new Converter();
            Assert.AreEqual("MXII", c.ConvertNumberstoRomanNumerals(1012));
        }
        [Test]
        public void TestConvertComboBackwards3999()
        {
            Converter c = new Converter();
            Assert.AreEqual("MMMCMXCIX", c.ConvertNumberstoRomanNumerals(3999));
        }
        [Test]
        public void TestConvertComboBackwards102()
        {
            Converter c = new Converter();
            Assert.AreEqual("CII", c.ConvertNumberstoRomanNumerals(102));
        }
        [Test]
        public void TestConvertComboBackwards1000()
        {
            Converter c = new Converter();
            Assert.AreEqual("M", c.ConvertNumberstoRomanNumerals(1000));
        }
        [Test]
        public void TestConvertComboBackwards120()
        {
            Converter c = new Converter();
            Assert.AreEqual("CXX", c.ConvertNumberstoRomanNumerals(120));
        }
        [Test]
        public void TestTwoDigitTwo()
        {
            Converter c = new Converter();
            Assert.AreEqual("XII", c.TwoDigit(12));
        }
        [Test]
        public void TestTwoDigitTwoXX()
        {
            Converter c = new Converter();
            Assert.AreEqual("XX", c.TwoDigit(20));
        }
        [Test]
        public void TestTwoDigitTwoXLI()
        {
            Converter c = new Converter();
            Assert.AreEqual("XLI", c.TwoDigit(41));
        }
        [Test]
        public void TestTwoDigitTwoXL()
        {
            Converter c = new Converter();
            Assert.AreEqual("XL", c.TwoDigit(40));
        }
        [Test]
        public void TestTwoDigitTwoLXII()
        {
            Converter c = new Converter();
            Assert.AreEqual("LXII", c.TwoDigit(62));
        }
        [Test]
        public void TestTwoDigitTwoLXXVIII()
        {
            Converter c = new Converter();
            Assert.AreEqual("LXXVIII", c.TwoDigit(78));
        }
        [Test]
        public void TestThreeDigitTwoCCCXLVIII()
        {
            Converter c = new Converter();
            Assert.AreEqual("CCCXLVIII", c.ThreeDigit(348));
        }
        [Test]
        public void TestThreeDigitTwoCDLXXVIII()
        {
            Converter c = new Converter();
            Assert.AreEqual("CDLXXVIII", c.ThreeDigit(478));
        }
        [Test]
        public void TestThreeDigitTwoDCCLIII()
        {
            Converter c = new Converter();
            Assert.AreEqual("DCCLIII", c.ThreeDigit(753));
        }
        [Test]
        public void TestForthDidgMMDCCLXXXIII()
        {
            Converter c = new Converter();
            Assert.AreEqual("MMDCCLXXXIII", c.ForthDidg(2783));
        }
        [Test]
        public void TestForthDigitMLIV()
        {
            Converter c = new Converter();
            Assert.AreEqual("MLIV", c.ForthDidg(1054));
        }
    }
}
