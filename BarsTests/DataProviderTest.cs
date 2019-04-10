using Bars.Models;
using Bars.Provider;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BarsTests
{
    public class DataProviderTest
    {
        private Mock<IDataParserProvider> _dataParserProvider;
        private Mock<IValidationProvider> _validationProvider;
        private IDataProvider _provider;

        [SetUp]
        public void Seup()
        {
            _dataParserProvider = new Mock<IDataParserProvider>();
            _validationProvider = new Mock<IValidationProvider>();
            _provider = new DataProvider(_dataParserProvider.Object, _validationProvider.Object);
        }

        [Test]
        public void LoadDataTest()
        {
            _validationProvider.Setup(vp => vp.CheckFirstSymbol(It.IsAny<string>())).Returns(string.Empty);

            var mockResult = new List<Bar>();
            var bar = new Bar();
            mockResult.Add(bar);

            _dataParserProvider.Setup(dpp => dpp.Parse(It.IsAny<string>())).Returns(mockResult);

            var result = _provider.LoadData(string.Empty);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
