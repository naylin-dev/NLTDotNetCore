namespace NLTDotNetCore.PizzaApi.Models.Pizza;

public class PizzaOrderInvoiceResponse
{
    public PizzaOrderInvoiceHeadModel Order { get; set; }
    public List<PizzaOrderInvoiceDetailModel> OrderDetails { get; set; }
}