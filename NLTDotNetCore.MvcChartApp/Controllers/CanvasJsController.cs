using Microsoft.AspNetCore.Mvc;
using NLTDotNetCore.MvcChartApp.Models.CanvasJS;

namespace NLTDotNetCore.MvcChartApp.Controllers;

public class CanvasJsController : Controller
{
    private readonly ILogger<CanvasJsController> _logger;

    public CanvasJsController(ILogger<CanvasJsController> logger)
    {
        _logger = logger;
    }

    // GET
    public IActionResult CandlestickCharts()
    {
        _logger.LogInformation("CandlestickCharts action called");
        CandlestickChartModel model = new CandlestickChartModel()
        {
            Data = new List<CandlestickChartDataModel>()
            {
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 1, 4),
                    y = new double[] { 109.000000, 122.180000, 104.959999, 111.389999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 1, 11),
                    y = new double[] { 112.129997, 117.779999, 101.209999, 104.040001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 1, 18),
                    y = new double[] { 106.570000, 110.139999, 97.050003, 100.720001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 1, 25),
                    y = new double[] { 99.779999, 102.680000, 90.110001, 91.839996 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 2, 1),
                    y = new double[] { 91.790001, 97.180000, 81.860001, 82.790001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 2, 8),
                    y = new double[] { 80.570000, 92.209999, 79.949997, 87.400002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 2, 15),
                    y = new double[] { 89.000000, 94.900002, 87.540001, 89.230003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 2, 22),
                    y = new double[] { 90.750000, 97.480003, 86.699997, 94.790001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 2, 28),
                    y = new double[] { 94.809998, 102.220001, 93.339996, 101.580002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 3, 7),
                    y = new double[] { 101.000000, 101.790001, 94.500000, 97.660004 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 3, 14),
                    y = new double[] { 97.199997, 102.410004, 96.430000, 101.120003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 3, 21),
                    y = new double[] { 101.150002, 102.099998, 97.070000, 98.360001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 3, 28),
                    y = new double[] { 98.339996, 105.790001, 97.820000, 105.699997 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 4),
                    y = new double[] { 105.900002, 106.440002, 102.820000, 103.809998 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 11),
                    y = new double[] { 104.040001, 111.849998, 102.209999, 111.510002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 18),
                    y = new double[] { 109.900002, 110.699997, 93.139999, 95.900002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 25),
                    y = new double[] { 95.699997, 95.750000, 88.209999, 90.029999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 2),
                    y = new double[] { 90.410004, 93.250000, 88.110001, 90.839996 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 9),
                    y = new double[] { 90.730003, 93.250000, 85.739998, 87.879997 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 16),
                    y = new double[] { 87.559998, 93.279999, 86.150002, 92.489998 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 23),
                    y = new double[] { 92.980003, 104.000000, 92.849998, 103.300003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 4, 30),
                    y = new double[] { 102.949997, 103.449997, 98.529999, 99.589996 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 5, 6),
                    y = new double[] { 100.290001, 101.629997, 93.279999, 93.750000 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 5, 13),
                    y = new double[] { 95.019997, 97.199997, 93.250000, 94.449997 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 5, 20),
                    y = new double[] { 95.220001, 95.879997, 87.209999, 88.440002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 5, 27),
                    y = new double[] { 87.879997, 97.000000, 84.809998, 96.669998 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 6, 4),
                    y = new double[] { 95.199997, 101.269997, 93.180000, 97.059998 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 6, 11),
                    y = new double[] { 96.190002, 98.699997, 94.089996, 98.389999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 6, 18),
                    y = new double[] { 98.430000, 99.839996, 84.500000, 85.889999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 6, 25),
                    y = new double[] { 85.730003, 93.099998, 85.010002, 91.250000 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 7, 1),
                    y = new double[] { 91.230003, 97.739998, 90.500000, 97.029999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 7, 8),
                    y = new double[] { 95.910004, 96.830002, 92.949997, 96.589996 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 7, 15),
                    y = new double[] { 96.830002, 97.220001, 94.400002, 95.870003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 7, 22),
                    y = new double[] { 95.669998, 98.250000, 94.910004, 97.580002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 7, 29),
                    y = new double[] { 96.970001, 98.849998, 96.570000, 97.379997 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 8, 5),
                    y = new double[] { 97.760002, 100.320000, 96.500000, 96.500000 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 8, 12),
                    y = new double[] { 95.910004, 99.489998, 95.330002, 99.480003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 8, 19),
                    y = new double[] { 99.900002, 100.349998, 93.260002, 95.940002 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 8, 26),
                    y = new double[] { 95.379997, 99.529999, 94.040001, 98.550003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 9, 3),
                    y = new double[] { 98.000000, 106.970001, 98.000000, 104.820000 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 9, 10),
                    y = new double[] { 103.180000, 104.529999, 97.629997, 101.470001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 9, 17),
                    y = new double[] { 100.500000, 127.849998, 98.379997, 127.500000 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 9, 24),
                    y = new double[] { 127.419998, 129.289993, 125.750000, 126.570000 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 9, 30),
                    y = new double[] { 126.849998, 126.900002, 121.620003, 122.029999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 10, 7),
                    y = new double[] { 124.260002, 125.809998, 113.110001, 114.779999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 10, 14),
                    y = new double[] { 114.750000, 116.809998, 110.680000, 115.209999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 10, 21),
                    y = new double[] { 116.199997, 119.459999, 116.190002, 117.410004 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 10, 28),
                    y = new double[] { 117.050003, 120.980003, 113.949997, 120.809998 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 11, 5),
                    y = new double[] { 120.730003, 126.349998, 118.400002, 122.879997 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 11, 12),
                    y = new double[] { 122.839996, 127.430000, 122.300003, 124.220001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 11, 19),
                    y = new double[] { 124.300003, 127.739998, 122.870003, 125.589996 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 11, 26),
                    y = new double[] { 126.239998, 129.070007, 123.599998, 123.800003 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 12, 4),
                    y = new double[] { 109.000000, 122.180000, 104.959999, 111.389999 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 12, 11),
                    y = new double[] { 112.129997, 117.779999, 101.209999, 104.040001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 12, 18),
                    y = new double[] { 106.570000, 110.139999, 97.050003, 100.720001 }
                },
                new CandlestickChartDataModel
                {
                    x = new DateOnly(2016, 12, 25),
                    y = new double[] { 99.779999, 102.680000, 90.110001, 91.839996 }
                }
            }
        };
        return View(model);
    }

    public IActionResult MultiSeriesBarChart()
    {
        MultiSeriesBarChartModel model = new MultiSeriesBarChartModel()
        {
            GoldMedal = new List<MultiSeriesBarChartGoldMedalModel>()
            {
                new() { Country = "Italy", Gold = 243 },
                new() { Country = "China", Gold = 236 },
                new() { Country = "France", Gold = 243 },
                new() { Country = "Great Britain", Gold = 273 },
                new() { Country = "Germany", Gold = 269 },
                new() { Country = "Russia", Gold = 196 },
                new() { Country = "USA", Gold = 1118 }
            },
            SilverMedal = new List<MultiSeriesBarChartSilverMedalModel>()
            {
                new() { Country = "Italy", Silver = 212 },
                new() { Country = "China", Silver = 186 },
                new() { Country = "France", Silver = 272 },
                new() { Country = "Great Britain", Silver = 299 },
                new() { Country = "Germany", Silver = 270 },
                new() { Country = "Russia", Silver = 165 },
                new() { Country = "USA", Silver = 896 }
            },
            BronzeMedal = new List<MultiSeriesBarChartBronzeMedalModel>()
            {
                new() { Country = "Italy", Bronze = 236 },
                new() { Country = "China", Bronze = 172 },
                new() { Country = "France", Bronze = 309 },
                new() { Country = "Great Britain", Bronze = 302 },
                new() { Country = "Germany", Bronze = 285 },
                new() { Country = "Russia", Bronze = 188 },
                new() { Country = "USA", Bronze = 788 }
            }
        };

        return View(model);
    }
}