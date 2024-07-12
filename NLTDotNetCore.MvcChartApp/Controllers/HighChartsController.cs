using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLTDotNetCore.MvcChartApp.Models.HighCharts;

namespace NLTDotNetCore.MvcChartApp.Controllers;

public class HighChartsController : Controller
{
    // GET
    public async Task<IActionResult> TimeSeriesLineChart()
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
}