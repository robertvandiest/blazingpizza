namespace BlazingPizza.Domain.Delivering.Entities
{
    public class Topping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
