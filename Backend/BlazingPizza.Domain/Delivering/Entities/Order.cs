namespace BlazingPizza.Domain.Delivering.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }

        public Address DeliveryAddress { get; set; } = new Address();

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public ICollection<OrderDeliveryStatus> DeliveryStatusses { get; set; }

    }
}
