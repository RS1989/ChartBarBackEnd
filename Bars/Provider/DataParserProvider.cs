using Bars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bars.Provider
{
    public interface IDataParserProvider
    {
        List<Bar> Parse(string data);
    }

    public class DataParserProvider : IDataParserProvider
    {
        private readonly IColorProvider _colorProvider; 
        public DataParserProvider(IColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }

        public List<Bar> Parse(string data)
        {
            var result = new List<Bar>();

            var barCommonArr = data.Split('#');
            foreach (var barNotFormatted in barCommonArr)
            {
                if (String.IsNullOrWhiteSpace(barNotFormatted))
                    continue;
                var bar = new Bar();
                var barInfo = barNotFormatted.Split(':');
                bar.BarName = barInfo[0];
                bar.BarColor = barInfo[1];
                bar.BarColorCode = _colorProvider.GetColorByName(barInfo[1]);
                if (Int64.TryParse(barInfo[2], out Int64 val))
                    bar.BarValue = val;
                else
                    throw new Exception($"Wrong value inside {barNotFormatted}");
                result.Add(bar);
            }

            return result;
        }
    }
}