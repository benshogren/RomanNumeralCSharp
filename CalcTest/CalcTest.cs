﻿using System;
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
    }
}
