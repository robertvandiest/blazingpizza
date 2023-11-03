using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Application.Ordering.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(PizzaService pizzaService, ILogger<PizzaController> logger)
        {
            _pizzaService = pizzaService;
            _logger = logger;
        }

        [HttpGet("specials", Name = nameof(GetPizzaSpecials))]
        public IEnumerable<PizzaSpecialDto> GetPizzaSpecials()
        {
            return _pizzaService.GetPizzaSpecials();
        }
    }
}