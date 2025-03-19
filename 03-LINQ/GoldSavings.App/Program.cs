using GoldSavings.App.Model;
using GoldSavings.App.Client;
using GoldSavings.App.Services;
namespace GoldSavings.App;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Gold Investor!");

        // Step 1: Get gold prices
        GoldDataService dataService = new GoldDataService();
        DateTime startDate = new DateTime(2024,09,18);
        DateTime endDate = DateTime.Now;
        List<GoldPrice> goldPrices = dataService.GetGoldPrices(startDate, endDate).GetAwaiter().GetResult();

        if (goldPrices.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService = new GoldAnalysisService(goldPrices);
        var avgPrice = analysisService.GetAveragePrice();
        

        // Step 3: Print results
        GoldResultPrinter.PrintSingleValue(Math.Round(avgPrice, 2), "Average Gold Price Last Half Year");

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        // Question 2.a


        // Step 1: Get gold prices
        GoldDataService dataService2 = new GoldDataService();
        DateTime startDate2 = new DateTime(2024,01,01);
        DateTime endDate2 = new DateTime(2024,12,31);
        List<GoldPrice> goldPrices2 = dataService2.GetGoldPrices(startDate2, endDate2).GetAwaiter().GetResult();

        if (goldPrices2.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService2 = new GoldAnalysisService(goldPrices2);
        var topBotPricesLastYear = analysisService2.GetTopBottomLastYearPrices();
        

       // Step 3: Print results
        Console.WriteLine("Top 3 Prices Last Year:");
        foreach (var price in topBotPricesLastYear.TopPrices)
        {
            GoldResultPrinter.PrintSingleValue(Math.Round(price, 2), "Price");
        }

        Console.WriteLine("Bottom 3 Prices Last Year:");
        foreach (var price in topBotPricesLastYear.BottomPrices)
        {
            GoldResultPrinter.PrintSingleValue(Math.Round(price, 2), "Price");
        }

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        // Question 2.b

        // Step 1: Get gold prices
        DateTime startDate3 = new DateTime(2020,01,11);
        DateTime endDate3 = DateTime.Now;
        List<GoldPrice> goldPrices3 = dataService.GetGoldPrices(startDate3, endDate3).GetAwaiter().GetResult();

        if (goldPrices3.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices3.Count} records. Ready for analysis.");

        // Step 2: Perform analysis
        GoldAnalysisService analysisService3 = new GoldAnalysisService(goldPrices3);
        var daysWithGain = analysisService3.GetDaysWithMoreThanFivePercentGain();

        // Step 3: Print results
        Console.WriteLine("Days with more than 5% gain since January 2020:");
        foreach (var date in daysWithGain)
        {
            Console.WriteLine(date.ToShortDateString());
        }

    }
}
