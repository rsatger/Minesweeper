using NUnit.Framework;
using System;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class InteractivityTest
    {
        [Test]
        public void CheckTypeIsInteger_Returns_False_When_Non_Integer_Input()
        {
            var interactivity = new Interactivity();
            string input;

            SimulateNonIntegerUserInput console = new SimulateNonIntegerUserInput();

            input = console.ReadUserInput();

            bool result = interactivity.CheckTypeIsInteger(input);

            Assert.IsFalse(result);
        }

        [Test]
        public void CheckTypeIsInteger_Returns_False_When_Input_Null()
        {
            var interactivity = new Interactivity();
            string input;

            SimulateNullUserInput console = new SimulateNullUserInput();

            input = console.ReadUserInput();

            bool result = interactivity.CheckTypeIsInteger(input);

            Assert.IsFalse(result);
        }

        [Test]
        public void CheckBoundaries_Returns_False_When_Input_Out_Of_Range()
        {
            DimensionType testDimension = DimensionType.Row;
            var interactivity = new Interactivity();
            int intInput;
            SimulateOutOfRangeUserInput console = new SimulateOutOfRangeUserInput();

            Int32.TryParse(console.ReadUserInput(), out intInput);

            bool result = interactivity.CheckBoundaries(intInput, testDimension);

            Assert.IsFalse(result);
        }
    }
}