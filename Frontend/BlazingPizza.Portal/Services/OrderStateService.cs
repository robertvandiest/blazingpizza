using BlazingPizza.API;

namespace BlazingPizza.Portal.Services
{
    public class OrderStateService
    {
        public bool ShowingConfigureDialog { get; private set; }

        public PizzaDto? ConfiguringPizza { get; private set; }

        public OrderDto Order { get; private set; } = GetDefaultOrder();

        public void ShowConfigurePizzaDialog(PizzaSpecialDto special)
        {
            ConfiguringPizza = new PizzaDto()
            {
                Special = special,
                Size = 12,
                Toppings = new List<ToppingDto>(),
            };

            ShowingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            if(Order.Pizzas is null)
                Order.Pizzas = new List<PizzaDto>();

            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void RemoveConfiguredPizza(PizzaDto pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        public void ResetOrder()
        {
            Order = GetDefaultOrder();
        }

        private static OrderDto GetDefaultOrder()
        {
            return new OrderDto
            {
                Pizzas = new List<PizzaDto>(),
                DeliveryAddress = new AddressDto
                {
                    City = "Test",
                    Line1 = "Test",
                    Line2 = "Test",
                    Name = "Test",
                    PostalCode = "Test",
                    Region = "Test"
                }
            };
        }
    }
}
