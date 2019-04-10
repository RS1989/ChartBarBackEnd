using Bars.Controllers;
using Bars.Models;
using Bars.Provider;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BarsTests
{
    public class BarControllerTest
    {
        private Mock<IDataProvider> _dataProvider;
        private Mock<IRandomizaProvider> _randomProvider;

        private BarController _controller;

        [SetUp]
        public void Setup()
        {
            _dataProvider = new Mock<IDataProvider>();
            _randomProvider = new Mock<IRandomizaProvider>();
            _controller = new BarController(_dataProvider.Object, _randomProvider.Object);
        }

        [Test]
        public void Randomize()
        {
            var bar = new Bar();
            bar.BarColor = "Test";
            bar.BarColorCode = "Test";
            bar.BarName = "Test";
            bar.BarValue = 1;
            var list = new List<Bar>();
            list.Add(bar);
            _controller.Request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:49980/api/random");
            var barMock = new Bar();
            barMock.BarColor = "Test";
            barMock.BarColorCode = "Test";
            barMock.BarName = "Test";
            barMock.BarValue = 2;
            var listMock = new List<Bar>();
            listMock.Add(barMock);
            _randomProvider.Setup(rp => rp.Randomize(It.IsAny<List<Bar>>())).Returns(listMock);
            IHttpActionResult result = _controller.Randomize(list);
            var contentResult = result as OkNegotiatedContentResult<List<Bar>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content[0].BarValue);
        }
    }
}
