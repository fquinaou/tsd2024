﻿using GoldSavings.App.Model;
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
        
        Console.WriteLine("Question 2.a");

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
        Console.WriteLine();

        GoldResultPrinter.PrintPrices(topBotPricesLastYear.TopPrices, "Top 3 Prices Last Year:");
        GoldResultPrinter.PrintPrices(topBotPricesLastYear.BottomPrices, "Bottom 3 Prices Last Year:");
       

        Console.WriteLine("\nGold Analyis Queries with LINQ Completed.");

        // Question 2.b

        Console.WriteLine("Question 2.b");


        // Step 1: Get gold prices

        DateTime startDate2020 = new DateTime(2020,01,01);
        DateTime endDate2020 = new DateTime(2020,01,31);
        List<GoldPrice> goldPrices2020 = dataService.GetGoldPrices(startDate2, endDate2).GetAwaiter().GetResult();
        GoldAnalysisService analysisService3 = new GoldAnalysisService(goldPrices2020);

        if (goldPrices2020.Count == 0)
        {
            Console.WriteLine("No data found. Exiting.");
            return;
        }

        Console.WriteLine($"Retrieved {goldPrices2020.Count} records. Ready for analysis.");

        var lowestPriceJan2020 = analysisService2.GetBottomPrices(1).First();
        var fiveP = lowestPriceJan2020.Price * 1.05;

        for (int year = 2020; year <= DateTime.Now.Year - 1; year++)
        {
            DateTime startDatetmp = new DateTime(year, 1, 1);
            DateTime endDatetmp = new DateTime(year, 12, 31);

            List<GoldPrice> goldPricestmp = dataService.GetGoldPrices(startDatetmp, endDatetmp).GetAwaiter().GetResult();
            GoldAnalysisService analysisServicetmp = new GoldAnalysisService(goldPricestmp);
            var superiorPrices = analysisServicetmp.superior(fiveP);
            
            GoldResultPrinter.PrintPrices(superiorPrices, "2.b. Days in ~" + year + "~ with more than 5% benefit when buying gold in January 2020");

        }



        //Question 2.c

        Console.WriteLine("Question 2.c");
        List<GoldPrice> goldPricesSecondTen = new List<GoldPrice>();
        for (int year = 2019; year <= 2022; year++)
        {
            DateTime startDatetmp = new DateTime(year, 1, 1);
            DateTime endDatetmp = new DateTime(year, 12, 31);

            List<GoldPrice> goldPricestmp = dataService.GetGoldPrices(startDatetmp, endDatetmp).GetAwaiter().GetResult();
            goldPricesSecondTen.AddRange(goldPricestmp);


        }
        GoldAnalysisService analysisService4 = new GoldAnalysisService(goldPricesSecondTen);
        var secondTenPrices = analysisService4.SecondTenPricesRank();

        GoldResultPrinter.PrintPrices(secondTenPrices, "2.c. Second Ten Prices Rank from 2019 to 2022");

        //Question 2.d

        Console.WriteLine("Question 2.d");

        int[] years ={2020, 2023, 2024};

        foreach (int year in years)
        {
            DateTime startDatetmp = new DateTime(year, 1, 1);
            DateTime endDatetmp = new DateTime(year, 12, 31);

            List<GoldPrice> goldPricestmp = dataService.GetGoldPrices(startDatetmp, endDatetmp).GetAwaiter().GetResult();
            GoldAnalysisService analysisServicetmp = new GoldAnalysisService(goldPricestmp);
            var avgPr = analysisServicetmp.GetAveragePrice();
            GoldResultPrinter.PrintSingleValue(Math.Round(avgPr, 2), "2.d. Average Gold Price in " + year);
        }

        //Question 2.e

        Console.WriteLine("Question 2.e");

        List<GoldPrice> lowestByYear = new List<GoldPrice>();
        for (int year = 2020; year <= 2024; year++)
        {
            DateTime startDatetmp = new DateTime(year, 1, 1);
            DateTime endDatetmp = new DateTime(year, 12, 31);

            List<GoldPrice> goldPricestmp = dataService.GetGoldPrices(startDatetmp, endDatetmp).GetAwaiter().GetResult();
            GoldAnalysisService analysisServicetmp = new GoldAnalysisService(goldPricestmp);
            var lowestPrice = analysisServicetmp.GetBottomPrices(1).First();
            lowestByYear.Add(lowestPrice);
        }

        GoldAnalysisService analysisService5 = new GoldAnalysisService(lowestByYear);

        GoldPrice lowestPrice = analysisService5.GetBottomPrices(1).First();


        List<GoldPrice> maxByYear = new List<GoldPrice>();
        for (int year = lowestPrice.Date.Year; year <= 2024; year++)
        {
            if (year == lowestPrice.Date.Year) {
                startDatetmp = minGlobal.Date.AddDays(1);
                endDatetmp = new DateTime(year, 12, 31);
            } else {
                startDatetmp = new DateTime(year, 1, 1);
                endDatetmp = new DateTime(year, 12, 31);                
            }

            List<GoldPrice> goldPricestmp = dataService.GetGoldPrices(startDatetmp, endDatetmp).GetAwaiter().GetResult();
            GoldAnalysisService analysisServicetmp = new GoldAnalysisService(goldPricestmp);
            var topPrice = analysisServicetmp.GetTopPrices(1).First();
            maxByYear.Add(topPrice);
        }

        GoldAnalysisService analysisService6 = new GoldAnalysisService(maxByYear);

        GoldPrice maxPrice = analysisService6.GetTopPrices(1).First();
        

    }
}
