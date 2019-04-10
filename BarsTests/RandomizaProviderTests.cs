using Bars.Models;
using Bars.Provider;
using NUnit.Framework;
using System.Collections.Generic;

namespace BarsTests
{
    public class RandomizaProviderTests
    {
        private  IRandomizaProvider _provider;

        [SetUp]
        public void Seup()
        {
            _provider = new RandomizaProvider();
        }

        [Test]
        public void RandomizeTest()
        {
            var inputList = new List<Bar>();
            var bar = new Bar();
            bar.BarValue = 0;
            inputList.Add(bar);
            var expectedVal = 0;

            var result = _provider.Randomize(inputList);

            Assert.IsTrue(expectedVal != result[0].BarValue);
        }
    }
}
