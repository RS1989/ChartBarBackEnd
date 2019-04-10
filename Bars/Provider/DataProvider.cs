using Bars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bars.Provider
{
    public interface IDataProvider
    {
        List<Bar> LoadData(string data);
    }

    public class DataProvider:IDataProvider
    {
        private readonly IDataParserProvider _dataParserProvider;
        private readonly IValidationProvider _validationProvider;

        public DataProvider(IDataParserProvider dataParserProvider, IValidationProvider validationProvider)
        {
            _dataParserProvider = dataParserProvider;
            _validationProvider = validationProvider;
        }

        public List<Bar> LoadData(string data)
        {
            var checkFirstSymbol = _validationProvider.CheckFirstSymbol(data);
            if (!string.IsNullOrWhiteSpace(checkFirstSymbol))
                throw new Exception(checkFirstSymbol);

            return _dataParserProvider.Parse(data);
        }
    }    
}