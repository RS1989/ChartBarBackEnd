using Bars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bars.Provider
{
    public interface IRandomizaProvider
    {
        List<Bar> Randomize(List<Bar> data);
    }

    public class RandomizaProvider: IRandomizaProvider
    {
        public RandomizaProvider()
        { }

        public List<Bar> Randomize(List<Bar> data)
        {
            var randomNumbers = this.GetRandomNumbers(data);
            for (var i = 0; i < randomNumbers.Count; i++)
            {
                data[i].BarValue = randomNumbers[i];
            }
            return data;
        }

        private List<int> GetRandomNumbers(List<Bar> data)
        {
            Random random = new Random();
            var result = Enumerable.Range(1, 100).OrderBy(x => random.Next()).Take(data.Count).ToList();
            return result;
        }
    }    
}