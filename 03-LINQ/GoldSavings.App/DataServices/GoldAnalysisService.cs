using System;
using System.Collections.Generic;
using System.Linq;
using GoldSavings.App.Model;

namespace GoldSavings.App.Services
{
    public class GoldAnalysisService
    {
        private readonly List<GoldPrice> _goldPrices;

        public GoldAnalysisService(List<GoldPrice> goldPrices)
        {
            _goldPrices = goldPrices;
        }
        public double GetAveragePrice()
        {
            return _goldPrices.Average(p => p.Price);
        }


        //Top (n) Prices Prices
        public IEnumerable<double> GetTopPrices(int n)
        {
            return _goldPrices.OrderByDescending(p => p.Price).Take(n).Select(p => p.Price);
        }

        //Bottom (n) Prices Prices

        public IEnumerable<double> GetBottomPrices(int n)
        {
            return _goldPrices.OrderBy(p => p.Price).Take(n).Select(p => p.Price);
        }

        public (IEnumerable<double> TopPrices, IEnumerable<double> BottomPrices) GetTopBottomLastYearPrices()
        {
            var topPrices = GetTopPrices(3);
            var bottomPrices = GetBottomPrices(3);
            
            return (topPrices, bottomPrices);
        }

        public IEnumerable<DateTime> GetDaysWithMoreThanFivePercentGain()
        {
            var january2020Prices = _goldPrices.Where(p => p.Date.Year == 2020 && p.Date.Month == 1).ToList();
            if (!january2020Prices.Any()) return Enumerable.Empty<DateTime>();

            var initialPrice = january2020Prices.First().Price;
            var daysWithGain = _goldPrices.Where(p => p.Price > initialPrice * 1.05).Select(p => p.Date);

            return daysWithGain;
        }
    }
}
