using BlazingPizza.Domain.Ordering.Enums;

namespace BlazingPizza.Domain.Ordering.Entities
{
    public class Order
    {

        public int OrderId { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedTime { get; set; }

        public OrderStatus Status { get; set; }

        public Address DeliveryAddress { get; set; } = new Address();

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());

    }
}
