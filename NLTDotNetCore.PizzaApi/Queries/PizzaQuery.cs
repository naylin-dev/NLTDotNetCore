namespace NLTDotNetCore.PizzaApi.Queries;

public class PizzaQuery
{
    public static string PizzaOrderQuery { get; } =
        @"
            SELECT po.*, p.Pizza, p.Price 
            FROM Tbl_PizzaOrder po 
            INNER JOIN Tbl_Pizza p 
            ON p.PizzaId = po.PizzaId 
            WHERE PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;
        ";

    public static string PizzaOrderDetailQuery { get; } =
        @"
            SELECT pod.*, pe.PizzaExtraName, pe.Price
            FROM Tbl_PizzaOrderDetail pod 
            INNER JOIN Tbl_PizzaExtra pe 
            ON pod.PizzaExtraId = pe.PizzaExtraId
            WHERE PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;
        ";
}