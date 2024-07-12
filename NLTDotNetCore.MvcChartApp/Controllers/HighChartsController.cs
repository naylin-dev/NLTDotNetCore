using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLTDotNetCore.MvcChartApp.Models.HighCharts;

namespace NLTDotNetCore.MvcChartApp.Controllers;

public class HighChartsController : Controller
{
    // GET
    public IActionResult TimeSeriesLineChart()
    {
        TimeSeriesLineChartModel model = new TimeSeriesLineChartModel()
        {
            Data = new double[][]
            {
                new double[] { 1262304000000, 0.7537 },
                new double[] { 1262563200000, 0.6951 },
                new double[] { 1262649600000, 0.6925 },
                new double[] { 1262736000000, 0.697 },
                new double[] { 1262822400000, 0.6992 },
                new double[] { 1262908800000, 0.7007 },
                new double[] { 1263168000000, 0.6884 },
                new double[] { 1263254400000, 0.6907 },
                new double[] { 1263340800000, 0.6868 },
                new double[] { 1263427200000, 0.6904 },
                new double[] { 1263513600000, 0.6958 },
                new double[] { 1263772800000, 0.696 },
                new double[] { 1263859200000, 0.7004 },
                new double[] { 1263945600000, 0.7077 },
                new double[] { 1264032000000, 0.7111 },
                new double[] { 1264118400000, 0.7076 },
                new double[] { 1264377600000, 0.7068 },
                new double[] { 1264464000000, 0.7101 },
                new double[] { 1264550400000, 0.7107 }
            },
        };
        return View(model);
    }

    public IActionResult BubbleChart()
    {
        BubbleChartModel model = new BubbleChartModel()
        {
            Data = new List<BubbleChartDataModel>()
            {
                new BubbleChartDataModel()
                {
                    x = 95,
                    y = 95,
                    z = 13.8,
                    name = "BE",
                    country = "Belgium"
                },
                new BubbleChartDataModel()
                {
                    x = 86.5,
                    y = 102.9,
                    z = 14.7,
                    name = "DE",
                    country = "Germany"
                },
                new BubbleChartDataModel()
                {
                    x = 80.8,
                    y = 91.5,
                    z = 15.8,
                    name = "FI",
                    country = "Finland"
                },
                new BubbleChartDataModel()
                {
                    x = 80.4,
                    y = 102.5,
                    z = 12,
                    name = "NL",
                    country = "Netherlands"
                },
                new BubbleChartDataModel()
                {
                    x = 80.3,
                    y = 86.1,
                    z = 11.8,
                    name = "SE",
                    country = "Sweden"
                },
                new BubbleChartDataModel()
                {
                    x = 78.4,
                    y = 70.1,
                    z = 16.6,
                    name = "ES",
                    country = "Spain"
                },
                new BubbleChartDataModel()
                {
                    x = 74.2,
                    y = 68.5,
                    z = 14.5,
                    name = "FR",
                    country = "France"
                },
                new BubbleChartDataModel()
                {
                    x = 73.5,
                    y = 83.1,
                    z = 10,
                    name = "NO",
                    country = "Norway"
                },
                new BubbleChartDataModel()
                {
                    x = 71,
                    y = 93.2,
                    z = 24.7,
                    name = "UK",
                    country = "United Kingdom"
                },
                new BubbleChartDataModel()
                {
                    x = 69.2,
                    y = 57.6,
                    z = 10.4,
                    name = "IT",
                    country = "Italy"
                },
                new BubbleChartDataModel()
                {
                    x = 68.6,
                    y = 20,
                    z = 16,
                    name = "RU",
                    country = "Russia"
                },
                new BubbleChartDataModel()
                {
                    x = 65.5,
                    y = 126.4,
                    z = 35.3,
                    name = "US",
                    country = "United States"
                },
                new BubbleChartDataModel()
                {
                    x = 65.4,
                    y = 50.8,
                    z = 28.5,
                    name = "HU",
                    country = "Hungary"
                },
                new BubbleChartDataModel()
                {
                    x = 63.4,
                    y = 51.8,
                    z = 15.4,
                    name = "PT",
                    country = "Portugal"
                },
                new BubbleChartDataModel()
                {
                    x = 64,
                    y = 82.9,
                    z = 31.3,
                    name = "NZ",
                    country = "New Zealand"
                }
            }
        };

        return View(model);
    }
}