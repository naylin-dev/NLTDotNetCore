using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLTDotNetCore.PizzaApi.Db;
using NLTDotNetCore.PizzaApi.Models.Pizza;
using NLTDotNetCore.PizzaApi.Queries;
using NLTDotNetCore.Shared;

namespace NLTDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly DapperService _dapperService;

        public PizzaController()
        {
            _appDbContext = new AppDbContext();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _appDbContext.PizzaExtras.ToListAsync();
            return Ok(lst);
        }

        // [HttpGet("Order/{invoiceNo}")]
        // public async Task<IActionResult> GetOrderAsync(string invoiceNo)
        // {
        //     var item = await _appDbContext.PizzaOrders.FirstOrDefaultAsync(x => x.PizzaOrderInvoiceNo == invoiceNo);
        //     var lst = await _appDbContext.PizzaOrderDetails.Where(x => x.PizzaOrderInvoiceNo == invoiceNo)
        //         .ToListAsync();
        //     return Ok(new
        //     {
        //         Order = item,
        //         OrderDetail = lst,
        //     });
        // }

        [HttpGet("Order/{invoiceNo}")]
        public IActionResult GetOrder(string invoiceNo)
        {
            var item = _dapperService.QueryFirstOrDefault<PizzaOrderInvoiceHeadModel>
            (
                PizzaQuery.PizzaOrderQuery,
                new { PizzaOrderInvoiceNo = invoiceNo }
            );

            var lst = _dapperService.Query<PizzaOrderInvoiceDetailModel>
            (
                PizzaQuery.PizzaOrderDetailQuery,
                new { PizzaOrderInvoiceNo = invoiceNo }
            );

            var model = new PizzaOrderInvoiceResponse()
            {
                Order = item,
                OrderDetails = lst
            };

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> OrderAsync(OrderRequestModel orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if (orderRequest.Extras.Length > 0)
            {
                var lstExtra = await _appDbContext.PizzaExtras.Where(x => orderRequest.Extras.Contains(x.Id))
                    .ToListAsync();
                total += lstExtra.Sum(x => x.Price);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");

            PizzaOrderModel pizzaOrderModel = new PizzaOrderModel()
            {
                PizzaId = orderRequest.PizzaId,
                PizzaOrderInvoiceNo = invoiceNo,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaExtraModels = orderRequest.Extras.Select(x => new PizzaOrderDetailModel
            {
                PizzaExtraId = x,
                PizzaOrderInvoiceNo = invoiceNo
            }).ToList();

            await _appDbContext.PizzaOrders.AddAsync(pizzaOrderModel);
            await _appDbContext.PizzaOrderDetails.AddRangeAsync(pizzaExtraModels);
            await _appDbContext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                Message = "Thank you for your order!",
                InvoiceNo = invoiceNo,
                TotalAmount = total
            };
            return Ok(response);
        }
    }
}