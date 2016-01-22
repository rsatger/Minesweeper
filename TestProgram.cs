using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Minesweeper
{
    [TestFixture]
    public class TestProgram
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
            //to do
        }

        [Test]
        public void ReadInput_Check_Input_Is_An_Integer()
        {
            //to do
        }
    }
}
