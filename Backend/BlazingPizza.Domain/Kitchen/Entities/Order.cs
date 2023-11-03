namespace BlazingPizza.Domain.Kitchen.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime CreatedTime { get; set; }

        public Address DeliveryAddress { get; set; } = new Address();

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

    }
}
