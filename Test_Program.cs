using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Minesweeper
{
    [TestFixture]
    public class ReadInputTests
    {
        [Test]
        public void ReadInput_Throws_When_Param_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Program.ReadInput(null);
            });
        }

        [Test]
        public void ReadInput_Check_Input_Bounds()
        {
            Assert.LessOrEqual(dimNumber);
        }

        [Test]
        public void ReadInput_Always_Returns_Interger_Between_0_And_10()
        {
            var program = new Program();

            var result = program.

        }
    }
}