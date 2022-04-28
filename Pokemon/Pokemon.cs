using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Pokemon
    {

        // Base-states
       
        public int HP_Base { get; set; }
        public int Attack_Base { get; set; }
        public int Defense_Base { get; set; }
        public int SpecialAttack_Base { get; set; }
        public int SpecialDefense_Base { get; set; }
        public int Speed_Base { get; set; }


        // Extra states

        public string Name { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int Level { get; private set; }

        // Statistics
        public double Average {
            get {
                return (HP_Base
                  + Attack_Base
                  + Defense_Base
                  + SpecialAttack_Base
                  + SpecialDefense_Base
                  + Speed_Base) / 6;
            }
        }
        public int Total {
            get {
                return (HP_Base
                      + Attack_Base
                      + Defense_Base
                      + SpecialAttack_Base
                      + SpecialDefense_Base
                      + Speed_Base);
            }
        }

        // Level-base statistics
        public int HP_Full {
            get { 
                return (((HP_Base + 50) * Level) / 50) + 10; 
            } 
        }

        public int Attack_Full
        {
            get
            {
                return ((Attack_Base * Level) / 50) + 5;
            }
        }
        public int Defense_Full
        {
            get
            {
                return ((Defense_Base * Level) / 50) + 5;
            }
        }
        public int SpecialAttack_Full {
            get
            {
                return ((SpecialAttack_Base * Level) / 50) + 5;
            }
        }
        public int SpecialDefense_Full {
            get
            {
                return ((SpecialDefense_Base * Level) / 50) + 5;
            }
        }
        public int Speed_Full
        {
            get
            {
                return ((Speed_Base * Level) / 50) + 5;
            }
        }
        //reeds bestaande properties en methoden

        //ShowInfo
        public void ShowInfo() {
            Console.WriteLine($"{Name} (level {Level})");

            Console.WriteLine("Base stats:");
            Console.WriteLine($"\t* Health = {HP_Base}");
            Console.WriteLine($"\t* Attack = {Attack_Base}");
            Console.WriteLine($"\t* Speed = {Speed_Base}");
            Console.WriteLine($"\t* Defense = {Defense_Base}");
            Console.WriteLine($"\t* Special Attack = {SpecialAttack_Base}");
            Console.WriteLine($"\t* Special Defense = {SpecialDefense_Base}");

            Console.WriteLine("Full stats:");
            Console.WriteLine($"\t* Health = {HP_Full}");
            Console.WriteLine($"\t* Attack = {Attack_Full}");
            Console.WriteLine($"\t* Speed = {Speed_Full}");
            Console.WriteLine($"\t* Defense = {Defense_Full}");
            Console.WriteLine($"\t* Special Attack = {SpecialAttack_Full}");
            Console.WriteLine($"\t* Special Defense = {SpecialDefense_Full}");


        }
        public void VerhoogLevel()
        {
            if (NoLevelingAllowed)
            {
                Console.WriteLine("Leveling of Pokemons is not allowed. Change NoLevelingAllowed to false to reenable leveling");
            }
            else
            {
                TimesLeveled++;
                Level++;
            }
        }

        //Default constructor
        private Pokemon()
        {
            HP_Base = 10;
            Attack_Base = 10;
            Defense_Base = 10;
            SpecialAttack_Base = 10;
            SpecialDefense_Base = 10;
            Speed_Base = 10;
        }
        //Overloaded constructor
        private Pokemon(int hp, int att, int def, int spec_att, int spec_def, int speed)
        {
            HP_Base = hp;
            Attack_Base = att;
            Defense_Base = def;
            SpecialAttack_Base = spec_att;
            SpecialDefense_Base = spec_def;
            Speed_Base = speed;
        }
        //static deel
        public static int TimesLeveled { get; private set; }
        public static int TimesBattled { get; private set; }
        public static int TimesBattleDraw { get; private set; }
        public static int TimesRandomGenerated { get; private set; }
        public static bool NoLevelingAllowed { get; set; }
        public static void Info()
        {
            Console.WriteLine($"Aantal keer geleveled:{TimesLeveled}");
            Console.WriteLine($"Aantal keer gevochten:{TimesBattled}");
            Console.WriteLine($"Waarvan {TimesBattleDraw} keren gelijke stand");
            Console.WriteLine($"Er werden {TimesRandomGenerated} random pokemons aangemaakt");
        }
        private static Random ran = new Random();
        public static Pokemon GeneratorPokemon()
        {
            TimesRandomGenerated++;
            Pokemon temp = new Pokemon();
            temp.HP_Base = ran.Next(1, 100);
            temp.Attack_Base = ran.Next(1, 100);
            return temp;
        }
        public static int Battle(Pokemon poke1, Pokemon poke2)
        {
            TimesBattled++;
            if (poke1 == null && poke2 == null)
            {
                return 0;
            }
            else if (poke1 == null)
            {
                return 2;
            }
            else if (poke2 == null)
            {
                return 1;
            }
            else if (poke1.Average > poke2.Average)
            {
                return 1;
            }
            else if (poke1.Average == poke2.Average)
            {
                return 0;
            }
            else
            {
                return 2;
            }
            return 0;
        }
    }
}
