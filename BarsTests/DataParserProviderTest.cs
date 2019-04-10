using Bars.Models;
using Bars.Provider;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BarsTests
{
    public class DataParserProviderTest
    {
        private Mock<IColorProvider> _colorProvider;
        private IDataParserProvider _provider;

        [SetUp]
        public void Seup()
        {
            _colorProvider = new Mock<IColorProvider>();
            _provider = new DataParserProvider(_colorProvider.Object);
        }

        [Test]
        [TestCase("#A:RED:5", "#FF0000", "A", 5)]
        [TestCase("#A:RED:5#A:RED:5", "#FF0000", "A", 5)]
        public void ParseTest(string input, string moqColor, string expectedName, int expectedVal)
        {
            _colorProvider.Setup(c => c.GetColorByName(It.IsAny<string>())).Returns(moqColor);
            var result = _provider.Parse(input);

            Assert.IsTrue(result[0].BarColorCode == moqColor);
            Assert.IsTrue(result[0].BarName == expectedName);
            Assert.IsTrue(result[0].BarValue == expectedVal);
        }
    }
}
