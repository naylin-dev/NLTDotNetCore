namespace NLTDotNetCore.PizzaApi.Models.Pizza;

public class OrderRequestModel
{
    public int PizzaId { get; set; }

    public int[] Extras { get; set; }
}