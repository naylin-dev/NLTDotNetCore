namespace NLTDotNetCore.MvcChartApp.Models.CanvasJS;

public class CandlestickChartModel
{
    public List<CandlestickChartDataModel> Data { get; set; }
}

public class CandlestickChartDataModel
{
    public DateOnly x { get; set; }
    public double[] y { get; set; }
}