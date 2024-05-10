namespace NLTDotNetCore.RestApiWithNLayer.Models;

public class LatHtaukBayDinModel
{
    public QuestionsModel[] questions { get; set; }
    public AnswersModel[] answers { get; set; }
    public string[] numberList { get; set; }
}