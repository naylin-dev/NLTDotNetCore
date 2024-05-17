using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLTDotNetCore.PizzaApi.Models.Pizza;

[Table("Tbl_PizzaOrderDetail")]
public class PizzaOrderDetailModel
{
    [Key]
    public int PizzaOrderDetailId { get; set; }

    public string PizzaOrderInvoiceNo { get; set; }

    public int PizzaExtraId { get; set; }
}