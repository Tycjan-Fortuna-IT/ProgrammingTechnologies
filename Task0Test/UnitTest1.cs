using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace Calculator.CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMethodTest()
        {
            int x = 12;
            int y = 13;

            Calculator c = new Calculator();

            Assert.AreEqual(x + y,c.Add(x, y));
        }

        [TestMethod]
        public void SubtractMethodTest()
        {
            int x = 10;
            int y = 11;

            Calculator c = new Calculator();

            Assert.AreEqual(x - y, c.Subtract(x, y));
        }

        [TestMethod]
        public void MultiplyMethodTest()
        {
            int x = 5;
            int y = 6;

            Calculator c = new Calculator();

            Assert.AreEqual(x * y, c.Multiply(x, y));
        }

        [TestMethod]
        public void DivideMethodTest()
        {
            int x = 10;
            int y = 5;

            Calculator c = new Calculator();

            Assert.AreEqual(x / y, c.Divide(x, y));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DivideByZeroMethodTest()
        {
            int x = 10;
            int y = 0;

            Calculator c = new Calculator();

            var result = c.Divide(x, y);
        }
    }
}