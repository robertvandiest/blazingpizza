using BlazingPizza.API;

namespace BlazingPizza.Portal.Services
{
    public class PricingService
    {
        public decimal GetBasePrice(PizzaDto input)
        {
            return ((decimal)input.Special.BasePrice / 12) * input.Size;
        }

        public decimal GetTotalPrice(OrderDto input)
        {
            if (input.Pizzas is null || !input.Pizzas.Any())
                return 0.0m;

            return input.Pizzas.Sum(p => GetBasePrice(p));
        }

        public decimal GetTotalPrice(PizzaDto input)
        {
            return GetBasePrice(input);
        }

        public string GetFormattedTotalPrice(PizzaDto input)
        {
            return GetTotalPrice(input).ToString("0.00");
        }

        public string GetFormattedTotalPrice(OrderDto input)
        {
            return GetTotalPrice(input).ToString("0.00");
        }
    }
}
