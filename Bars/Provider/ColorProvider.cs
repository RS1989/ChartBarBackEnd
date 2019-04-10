using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bars.Provider
{
    public interface IColorProvider
    {
        string GetColorByName(string name);
    }

    public class ColorProvider: IColorProvider
    {
        private Dictionary<string, string> _colors;

        public ColorProvider()
        {
            _colors = new Dictionary<string, string>();
            _colors.Add("RED", "rgba(255, 127, 127, 0.3)");
            _colors.Add("GREEN", "rgba(173, 255, 47, 0.3)");
            _colors.Add("BLUE", "rgba(127, 127, 255, 0.3)");
            _colors.Add("GRAY", "rgba(211, 211, 211, 0.3)");
            _colors.Add("BLACK", "rgba(0, 0, 0, 0.3)");
            _colors.Add("YELLOW", "rgba(255, 255, 0, 0.3)");
        }

        public string GetColorByName(string name)
        {
            if (_colors.TryGetValue(name.ToUpper(), out string value))
            {
                return value;
            }
            else
            {
                throw new Exception($"Color {name} doesn't exist in sysytem");
            }
        }
    }
}