using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class ReadInputTests
    {
        [Test]
        public void ReadInput_Throws_When_Param_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Program.ReadInput(null);
            });
        }

        [Test]
        public void ReadInput_Check_Input_Bounds()
        {
            //Assert.LessOrEqual(dimNumber);
        }

        [Test]
        public void ReadInput_Always_Returns_Interger_Between_0_And_10()
        {
            var interactivity = new Interactivity();

            double result = interactivity.ReadInput("row");

            Assert.GreaterOrEqual(0, result);
            Assert.LessOrEqual(0, result);
            Assert.LessOrEqual(0, result);
            //Assert.True(result.GetType() is Double);
        }
    }
}