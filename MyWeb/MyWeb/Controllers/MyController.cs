using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;
namespace MyWeb.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase
    {
        [HttpGet(Name = "GetMyController")]

        public string SayHello(string name)
        {
            return $"Hello {name}";
        }

        [HttpPost(Name = "PostMyController")]

        public OrderItem Somefunc(Order order)
        {
            List<OrderItem> items = order.Items;
            int minPriceIndex = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Price < items[minPriceIndex].Price)
                {
                    minPriceIndex= i;
                }
            }
            return items[minPriceIndex];
        }
    }
}

