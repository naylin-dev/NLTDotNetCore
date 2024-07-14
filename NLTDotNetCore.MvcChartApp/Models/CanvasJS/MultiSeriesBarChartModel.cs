using Newtonsoft.Json;

namespace NLTDotNetCore.MvcChartApp.Models.CanvasJS;

public class MultiSeriesBarChartModel
{
    public List<MultiSeriesBarChartGoldMedalModel> GoldMedal { get; set; }
    public List<MultiSeriesBarChartSilverMedalModel> SilverMedal { get; set; }
    public List<MultiSeriesBarChartBronzeMedalModel> BronzeMedal { get; set; }
}

public class MultiSeriesBarChartGoldMedalModel
{
    [JsonProperty("label")]
    public string Country { get; set; }

    [JsonProperty("y")]
    public int Gold { get; set; }
}

public class MultiSeriesBarChartSilverMedalModel
{
    [JsonProperty("label")]
    public string Country { get; set; }

    [JsonProperty("y")]
    public int Silver { get; set; }
}

public class MultiSeriesBarChartBronzeMedalModel
{
    [JsonProperty("label")]
    public string Country { get; set; }

    [JsonProperty("y")]
    public int Bronze { get; set; }
}