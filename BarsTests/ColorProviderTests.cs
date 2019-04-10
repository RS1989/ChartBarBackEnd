using Bars.Provider;
using NUnit.Framework;

namespace Tests
{
    public class ColorProviderTests
    {
        private IColorProvider _provider;
        [SetUp]
        public void Setup()
        {
            _provider = new ColorProvider();

        }

        [Test]
        [TestCase("RED", "rgba(255, 127, 127, 0.3)")]
        [TestCase("red", "rgba(255, 127, 127, 0.3)")]
        public void GetColorByNameTest(string input, string expectedResult)
        {
            var result = _provider.GetColorByName(input);
            Assert.IsTrue(result.Equals(expectedResult));
        }
    }
}