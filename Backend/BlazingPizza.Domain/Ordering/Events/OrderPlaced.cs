namespace BlazingPizza.Domain.Ordering.Events
{
    public class OrderPlaced
    {
        public int OrderId { get; set; }

        public DateTime CreatedTime { get; set; }

        public OrderPlacedAddress DeliveryAddress { get; set; }

        public ICollection<OrderPlacedPizza> Pizzas { get; set; }
    }

    public class OrderPlacedAddress
    {
        public string Name { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }
    }

    public class OrderPlacedPizza
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int Size { get; set; }

        public virtual ICollection<string> Toppings { get; set; }

    }
}
