using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcClassBr;

namespace UnitTest.Lab1
{
    [TestClass]
    public class CalcClassAddTests
    {
        public TestContext TestContext { get; set; }

        // 1. Тести на нормальне додавання
        [TestMethod]
        public void Add_PositiveNumbers_ReturnsCorrectSum()
        {
            long a = 2;
            long b = 4;
            int expected = 6;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            long a = -5;
            long b = -3;
            int expected = -8;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_PositiveAndNegative_ReturnsCorrectSum()
        {
            long a = 10;
            long b = -3;
            int expected = 7;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_WithZero_ReturnsCorrectSum()
        {
            long a = 15;
            long b = 0;
            int expected = 15;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_BothZeros_ReturnsZero()
        {
            long a = 0;
            long b = 0;
            int expected = 0;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        // 2. Тести на граничні значення
        [TestMethod]
        public void Add_MaxIntWithZero_ReturnsMaxInt()
        {
            long a = int.MaxValue;
            long b = 0;
            int expected = int.MaxValue;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_MinIntWithZero_ReturnsMinInt()
        {
            // Arrange
            long a = int.MinValue;
            long b = 0;
            int expected = int.MinValue;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        // 3. Тести на переповнення РЕЗУЛЬТАТУ
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_ResultExceedsMaxValue_ThrowsException()
        {
            long a = int.MaxValue;
            long b = 1;

            CalcClass.Add(a, b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_ResultBelowMinValue_ThrowsException()
        {
            long a = int.MinValue;
            long b = -1;

            CalcClass.Add(a, b);
        }

        // 4. Тести на переповнення ВХІДНИХ ПАРАМЕТРІВ
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_FirstParameterExceedsIntRange_ThrowsException()
        {
            long a = (long)int.MaxValue + 1;
            long b = 1;

            CalcClass.Add(a, b);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_SecondParameterExceedsIntRange_ThrowsException()
        {
            long a = 1;
            long b = (long)int.MinValue - 1;

            CalcClass.Add(a, b);
        }

        // 5. Тест з базою даних 
        [TestMethod]
        [DataSource("System.Data.SqlClient",
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=lab1.test;Integrated Security=True;",
        "TestData",
        DataAccessMethod.Sequential)]
        public void Add_FromDatabase_ReturnsCorrectResult()
        {
            long numA = Convert.ToInt64(TestContext.DataRow["NumA"]);
            long numB = Convert.ToInt64(TestContext.DataRow["NumB"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Expected"]);

            int actual = CalcClass.Add(numA, numB);

            Assert.AreEqual(expected, actual);
        }

        // 6. Додатковий тест для великих чисел, що не викликають переповнення
        [TestMethod]
        public void Add_LargeNumbersWithinRange_ReturnsCorrectSum()
        {
            long a = 1000000;
            long b = 2000000;
            int expected = 3000000;

            int actual = CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }
    }

}