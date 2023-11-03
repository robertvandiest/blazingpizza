using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingPizza.Infrastructure.Ordering.EntityFramework.Migrations
{
    public partial class PrefixTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ordering");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Toppings",
                newSchema: "Ordering");

            migrationBuilder.RenameTable(
                name: "Specials",
                newName: "Specials",
                newSchema: "Ordering");

            migrationBuilder.RenameTable(
                name: "PizzaTopping",
                newName: "PizzaTopping",
                newSchema: "Ordering");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Pizzas",
                newSchema: "Ordering");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "Ordering");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Address",
                newSchema: "Ordering");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Toppings",
                schema: "Ordering",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "Specials",
                schema: "Ordering",
                newName: "Specials");

            migrationBuilder.RenameTable(
                name: "PizzaTopping",
                schema: "Ordering",
                newName: "PizzaTopping");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                schema: "Ordering",
                newName: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "Ordering",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "Ordering",
                newName: "Address");
        }
    }
}
