namespace BlazingPizza.Application.Ordering.Dto
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class PizzaDto
    {
        public int Size { get; set; }

        public PizzaSpecialDto Special { get; set; }

        public ICollection<ToppingDto> Toppings { get; set; }

    }
}
