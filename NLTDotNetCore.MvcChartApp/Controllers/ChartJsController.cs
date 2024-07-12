using Microsoft.AspNetCore.Mvc;
using NLTDotNetCore.MvcChartApp.Models;
using NLTDotNetCore.MvcChartApp.Models.ChartJs;

namespace NLTDotNetCore.MvcChartApp.Controllers;

public class ChartJsController : Controller
{
    /// <summary>
    /// Generates an array of two random numbers within the specified range.
    /// </summary>
    /// <param name="max">The maximum value of the range (inclusive).</param>
    /// <param name="min">The minimum value of the range (inclusive).</param>
    /// <returns>An array of two random numbers within the specified range.</returns>
    public int[] GenerateRandomNumber(int max, int min)
    {
        Random rand = new Random();
        return new[] { rand.Next(min, max + 1), rand.Next(min, max + 1) };
    }

    // GET
    public IActionResult FloatingBarsChart()
    {
        FloatingBarsChartModel model = new FloatingBarsChartModel()
        {
            Labels = new[]
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                "November", "December"
            },
            Data1 = new int[12][],
            Data2 = new int[12][],
        };

        for (int i = 0; i < 12; i++)
        {
            model.Data1[i] = GenerateRandomNumber(100, -100);
            model.Data2[i] = GenerateRandomNumber(100, -100);
        }

        return View(model);
    }
}