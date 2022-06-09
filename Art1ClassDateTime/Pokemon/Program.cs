using System;

namespace Pokemon
{
    internal class Program
    {
        private static void Main(string[] args)
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

            LogBattle(pokemon1, pokemon2, Pokemon.Battle(pokemon1, pokemon2));
        }

        private static void LogBattle(Pokemon pokemon1, Pokemon pokemon2, int battle)
        {
            switch (battle)
            {
                case 0:
                    Console.WriteLine("Gelijke stand");
                    break;

                case 1:
                    Console.WriteLine($"Pokemon {pokemon1.Name} heeft gewonnen!");
                    break;

                case 2:
                    Console.WriteLine($"Pokemon {pokemon2.Name} heeft gewonnen!");
                    break;
            }
        }
    }
}