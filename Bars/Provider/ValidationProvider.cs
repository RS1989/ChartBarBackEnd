using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Bars.Provider
{
    public interface IValidationProvider
    {
        string CheckFirstSymbol(string data);
    }

    public class ValidationProvider : IValidationProvider
    {
        public ValidationProvider() { }

        

        public string CheckFirstSymbol(string data)
        {
            var resul = string.Empty;
            if (data[0] != '#')
            {
                resul = @"Data begin with wron character";
            }
            return resul;
        }
    }    
}