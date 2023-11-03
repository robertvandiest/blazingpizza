namespace BlazingPizza.Application.Ordering.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime CreatedTime { get; set; }

        public AddressDto DeliveryAddress { get; set; } = new AddressDto();

        public ICollection<PizzaDto> Pizzas { get; set; } = new List<PizzaDto>();
    }
}
