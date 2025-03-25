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
        public List<GoldPrice> GetTopPrices(int n)
        {
            return _goldPrices.OrderByDescending(p => p.Price).Take(n).ToList();  
        }

        //Bottom (n) Prices Prices

        public List<GoldPrice> GetBottomPrices(int n)
        {
            return _goldPrices.OrderBy(p => p.Price).Take(n).ToList();
        }

        public (List<GoldPrice> TopPrices, List<GoldPrice> BottomPrices) GetTopBottomLastYearPrices()
        {
            var topPrices = GetTopPrices(3);
            var bottomPrices = GetBottomPrices(3);
            
            return (topPrices, bottomPrices);
        }

        public List<GoldPrice> superior(double price)
        {
            return _goldPrices.Where(p => p.Price > price).ToList();
        }

        public List<GoldPrice> SecondTenPricesRank()
        {
            return _goldPrices.OrderByDescending(p => p.Price).Skip(10).Take(3).ToList();
        }
    }
}
