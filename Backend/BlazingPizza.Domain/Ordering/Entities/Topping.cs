namespace BlazingPizza.Domain.Ordering.Entities
{
    public class Topping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
