//using System.Linq;
//using NUnit.Framework;

//namespace Minesweeper.Tests
//{
//    [TestFixture]
//    public class InteractivityTest
//    {
//        private Interactivity _interactivity;
//        private SimulateCommunicator _simuCommunicator;

//        [SetUp]
//        public void SetUp()
//        {
//            _simuCommunicator = new SimulateCommunicator("");
//            _interactivity = new Interactivity(_simuCommunicator);
//        }

//        [Test]
//        [TestCase("1")]
//        public void CheckTypeIsInteger_Returns_Correct_Integer(string input)
//        {
//            int index = -1;
//            _interactivity.CheckTypeIsInteger(input, out index);
//            Assert.AreEqual(1, index);
//            Assert.AreEqual(0, _simuCommunicator.CountRead);
//        }

//        [Test]
//        [TestCase(null)]
//        [TestCase("sdflju")]
//        [TestCase("7.8")]
//        [TestCase("")]
//        [TestCase(" ")]
//        public void CheckTypeIsInteger_Returns_False_When_Input_Incorrect(string input)
//        {
//            int index;
//            Assert.False(_interactivity.CheckTypeIsInteger(input, out index));
//        }

//        [Test]
//        [TestCase(-1, DimensionType.Row)]
//        [TestCase(11, DimensionType.Column)]
//        [TestCase(11, DimensionType.Row)]
//        public void CheckBoundaries_Returns_False_When_Input_Out_Of_Range(int input, DimensionType dimension)
//        {
//            CollectionAssert.IsEmpty(_simuCommunicator.AllWrite);
//            Assert.False(_interactivity.CheckBoundaries(input, dimension));
//            Assert.AreEqual(string.Format(MessageResources.CheckBoundariesError, dimension), _simuCommunicator.AllWrite.Single());
//        }

//        [Test]
//        [TestCase(1)]
//        public void CheckBoundaries_Returns_True_When_Input_Is_Correct(int input)
//        {
//            Assert.True(_interactivity.CheckBoundaries(input, DimensionType.Column));
//        }
//    }
//}