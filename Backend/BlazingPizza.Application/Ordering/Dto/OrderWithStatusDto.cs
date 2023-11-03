namespace BlazingPizza.Application.Ordering.Dto
{
    public class OrderWithStatusDto
    {
        public OrderDto Order { get; set; }

        public string StatusText { get; set; }
    }
}
