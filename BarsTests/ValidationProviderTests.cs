using Bars.Models;
using Bars.Provider;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BarsTests
{
    public class ValidationProviderTests
    {
        private IValidationProvider _provider;

        [SetUp]
        public void Setup()
        {
            _provider = new ValidationProvider();
        }

      

        [Test]
        [TestCase("#1:A", "")]
        [TestCase("#A:1", "")]
        [TestCase("1#A:1>", "Data begin with wron character")]
        public void CheckFirstSymbolTest(string input, string expectedResult)
        {
            var result = _provider.CheckFirstSymbol(input);

            Assert.IsTrue(result == expectedResult);
        }
    }
}
