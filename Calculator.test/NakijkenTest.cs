using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Calculator;

namespace Calculator.test
{
    [TestClass]
    public class NakijkenTest
    {
        private IAgeCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            var type = typeof(IAgeCalculator);
            var calculatorType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.Name != "IAgeCalculator")
                .FirstOrDefault();
        

            calculator = (IAgeCalculator) Activator.CreateInstance(calculatorType);
        }

        [TestMethod]
        public void Input_Voldoet_Aan_Format()
        {
            //1. Arrange
            string input = "15-03-1990";
            DateTime result;

            //2. Act
            bool canParse = calculator.ParseInput(input, out result);

            //3. Assert
            Assert.IsTrue(canParse);
        }

        [TestMethod]
        public void Input_is_null()
        {
            //1. Arrange
            string input = null;
            DateTime result;

            //2. Act
            bool canParse = calculator.ParseInput(input, out result);

            //3. Assert
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Input_is_niet_correct()
        {
            //1. Arrange
            string input = "15/031990";
            DateTime result;

            //2. Act
            bool canParse = calculator.ParseInput(input, out result);

            //3. Assert
            Assert.IsFalse(canParse);
        }

        [TestMethod]
        public void Leeftijd_is_correct()
        {
            //1. Arrange
            DateTime dateOfBirth = new DateTime(1990, 03, 15);

            //2. Act
            int age = calculator.CalculateAge(dateOfBirth);

            //3. Assert
            Assert.AreEqual(27, age);
        }
    }
}
