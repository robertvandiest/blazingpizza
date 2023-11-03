namespace BlazingPizza.Application.Ordering.Dto
{
    public class OrderSummaryDto
    {
        public int OrderId { get; set; }

        public DateTime CreatedTime { get; set; }

        public int NumberOfItems { get; set; }

        public decimal TotalPrice { get; set; }

        public string OrderStatus { get; set; }
    }
}
