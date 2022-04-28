using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pokemon pokemon1 = Pokemon.GeneratorPokemon();
            pokemon1.Name = "Test Pokemon 1";
            pokemon1.Number = 1;
            pokemon1.Type = "snow & ice";
            pokemon1.ShowInfo();
            

           
            Pokemon pokemon2 = Pokemon.GeneratorPokemon();
            pokemon2.Name = "Test Pokemon 2";
            pokemon2.Number = 2;
            pokemon2.Type = "gras & moeraas";
            pokemon2.VerhoogLevel();
            pokemon2.VerhoogLevel();
            pokemon2.VerhoogLevel();
            pokemon2.ShowInfo();

         //   pokemon1 = null;
            int battle = Pokemon.Battle(pokemon1, pokemon2);
            switch (battle)
            {
                case 0:
                    Console.WriteLine("Gelijke stand");
                    break;
                case  1:
                    Console.WriteLine($"Pokemon {pokemon1.Name} heeft gewonnen!");
                    break;
                case  2:
                    Console.WriteLine($"Pokemon {pokemon2.Name} heeft gewonnen!");
                    break; 
            }
        }
    }
}
