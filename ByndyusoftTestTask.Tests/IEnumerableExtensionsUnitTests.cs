using ByndyusoftTestTask.Extensions;
using NUnit.Framework;

namespace ByndyusoftTestTask.Tests
{
    [TestFixture]
    public class IEnumerableExtensionsUnitTests
    {
        [Test]
        public void CallSumFirstNMinElementsMethod_WithValidArguments_ShouldReturnExpectedResult()
        {
            var elementArray = new int[] { 5, 6, -1, -2, -10 };
            var n = 2;
            var expectedResult = -12;
            var actualResult = elementArray.SumFirstNMinElements<int, int>(n);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CallSumFirstNMinElementsMethod_WithUninitializedElementCollection_ShouldThrowArgumentNullException()
        {
            var elementArray = default(int[]);
            var n = 2;

            Assert.That(() => elementArray.SumFirstNMinElements<int, int>(n), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CallSumFirstNMinElementsMethod_WithEmptyElementCollection_ShouldThrowArgumentException()
        {
            var elementArray = new int[] { };
            var n = 2;

            Assert.That(() => elementArray.SumFirstNMinElements<int, int>(n), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CallSumFirstNMinElementsMethod_WithNegativeN_ShouldThrowArgumentException()
        {
            var elementArray = new int[] { 1, 2, 3 };
            var n = -2;

            Assert.That(() => elementArray.SumFirstNMinElements<int, int>(n), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CallSumFirst2MinElementsMethod_WithValidArguments_ShouldReturnExpectedResult()
        {
            var elementArray = new int[] { 10, 9, 8, 3, -1, -1 };
            var expectedResult = -2;
            var actualResult = elementArray.SumFirst2MinElements<int, int>();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CallSumFirst2MinElementsMethod_WithUninitializedElementCollection_ShouldThrowArgumentNullException()
        {
            var elementArray = default(int[]);

            Assert.That(() => elementArray.SumFirst2MinElements<int, int>(), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CallSumFirst2MinElementsMethod_WithEmptyElementCollection_ShouldThrowArgumentException()
        {
            var elementArray = new int[] { };

            Assert.That(() => elementArray.SumFirst2MinElements<int, int>(), Throws.Exception.TypeOf<ArgumentException>());
        }
    }
}
