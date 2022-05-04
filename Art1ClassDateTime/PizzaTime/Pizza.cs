namespace PizzaTime
{
    public class Pizza
    {
        private string toppings;
        private int diameter;
        private double price;
        private string error;

        public Pizza()
        {
            toppings = "Pepperoni"; // most popular topping
            diameter = 36; // most popular 14 inches pizza in cm
            price = 0; // most popular pizza is free
            error = "";
        }

        public string Error
        {
            get
            { return error; }
        }

        public string Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                if (value != "")
                {
                    toppings = value;
                    error = "";
                }
                else
                {
                    error += "Input fout. Geef een of meer toppings in. ";
                }
            }
        }

        public int Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                if (value > 0)
                {
                    diameter = value;
                    error = "";
                }
                else
                {
                    error += "Input fout. Geef een diameter in. ";
                }
            }
        }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                {
                    price = value;
                    error = "";
                }
                else
                {
                    error += "Input fout. Geef een prijs in. ";
                }
            }
        }

        public override string ToString()
        {
            if (error == "")
                return $"Pizza {Toppings}, diameter {Diameter}cm, prijs {Price}euro is besteld. ";
            else return error;
        }
    }
}