using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssertionSample
{
    [TestClass]
    public class AssertExceptionSample
    {
        [TestMethod]
        public void Divide_positive()
        {
            var calculator = new Calculator();
            var actual = calculator.Divide(5, 2);
            Assert.AreEqual(2.5m, actual);
        }

        // use fluent assertion
        [TestMethod]
        public void Divide_Joey()
        {
            var calculator = new Calculator();
            Action action = () => { calculator.Divide(5, 91); };
            action.ShouldThrow<YouShallNotPassException>().And.PropDecimal.ShouldBeEquivalentTo(91);

            //how to assert expected exception?
        }
    }

    public class Calculator
    {
        public decimal Divide(decimal first, decimal second)
        {
            if (second == 0 || second == 91)
            {
                throw new YouShallNotPassException() { PropDecimal = second };
            }
            return first / second;
        }
    }

    public class YouShallNotPassException : Exception
    {
        public decimal PropDecimal { get; set; }
    }
}