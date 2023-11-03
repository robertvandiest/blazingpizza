using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Application.Ordering.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(OrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("summaries", Name = nameof(GetOrderSummaries))]
        public IEnumerable<OrderSummaryDto> GetOrderSummaries()
        {
            return _orderService.GetOrderSummaries();
        }

        [HttpGet("{orderId:int}", Name = nameof(GetOrder))]
        public OrderWithStatusDto GetOrder(int orderId)
        {
            return _orderService.GetOrder(orderId);
        }

        [HttpPost("submit", Name = nameof(SubmitOrder))]
        public async Task<int> SubmitOrder(OrderDto dto)
        {
            return await _orderService.SubmitOrder(dto);
        }
    }
}