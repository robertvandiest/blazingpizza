namespace BlazingPizza.Domain.Delivering.Entities
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
