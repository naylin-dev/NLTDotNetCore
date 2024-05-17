namespace NLTDotNetCore.PizzaApi.Models.Pizza;

public class OrderResponse
{
    public string Message { get; set; }

    public string InvoiceNo { get; set; }

    public decimal TotalAmount { get; set; }
}