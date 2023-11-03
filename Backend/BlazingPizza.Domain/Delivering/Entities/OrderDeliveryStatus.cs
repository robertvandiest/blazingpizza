using BlazingPizza.Domain.Delivering.Enums;

namespace BlazingPizza.Domain.Delivering.Entities
{
    public class OrderDeliveryStatus
    {
        public int OrderId { get; set; }

        public DeliveryStatus Status { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public virtual Order Order { get; set; }
    }
}
