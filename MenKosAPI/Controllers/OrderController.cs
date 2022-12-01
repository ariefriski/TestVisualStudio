using Microsoft.AspNetCore.Mvc;
using MenKosAPI.Base;
using MenKosAPI.Models;
using MenKosAPI.Repositories.Data;
using Microsoft.AspNetCore.Http;

namespace MenKosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController<OrderRepository, Order>
    {
        private readonly OrderRepository _orderRepository;
        public OrderController(OrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
