using System;

namespace PizzaTime
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Pizza pizza = new Pizza();
            Console.WriteLine($"(Most popular) {pizza.ToString()}");
            pizza.Toppings = "Black Olives";
            pizza.Diameter = 30;
            pizza.Price = 11.99;
            Console.WriteLine(pizza.ToString());
            pizza.Toppings = "";
            pizza.Diameter = 0;
            pizza.Price = -12.45;
            Console.WriteLine(pizza.ToString());
        }
    }
}