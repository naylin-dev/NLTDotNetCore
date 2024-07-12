namespace NLTDotNetCore.MvcChartApp.Models.HighCharts;

public class BubbleChartModel
{
    public List<BubbleChartDataModel> Data { get; set; }
}

public class BubbleChartDataModel
{
    public double x { get; set; }
    public double y { get; set; }
    public double z { get; set; }
    public string name { get; set; }
    public string country { get; set; }
}