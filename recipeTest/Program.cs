using System;

namespace RecipeApp
{
    class Recipe
    {
        private string[] ingredients;
        private string[] steps;

        public Recipe(int numIngredients, int numSteps)
        {
            ingredients = new string[numIngredients];
            steps = new string[numSteps];
        }
        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }

            public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
            }

            public override string ToString()
            {
                return $"{Quantity} {Unit} {Name}";
            }
        }

        public void EnterIngredients()
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.Write("Enter ingredient {0} name: ", i + 1);
                string name = Console.ReadLine();
                Console.Write("Enter ingredient {0} quantity: ", i + 1);
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Enter ingredient {0} unit of measurement: ", i + 1);
                string unit = Console.ReadLine();

                ingredients[i] = $"{name} - {quantity} {unit}";
            }
        }

        public void EnterSteps()
        {
            for (int i = 0; i < steps.Length; i++)
            {
                Console.Write("Enter step {0}: ", i + 1);
                steps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        public static void ScaleRecipe(Recipe recipe, double factor)  //broken
        {
            foreach (Ingredient quantity in recipe.ingredients)
            {
                Ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()  //broken
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].Quantity = ingredients.Quantity[i];
            }
        }

        public void ClearRecipe()
        {
            Console.WriteLine("Clearing recipe data...");
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RecipeApp!");

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(numIngredients, numSteps);
            recipe.EnterIngredients();
            recipe.EnterSteps();

            Console.WriteLine("\nHere is the recipe:");
            recipe.DisplayRecipe();

            while (true)
            {
                Console.WriteLine("\nWhat would you like to do next? (Enter a number)");
                Console.WriteLine("1. Scale the recipe");
                Console.WriteLine("2. Reset the quantities");
                Console.WriteLine("3. Clear the recipe and start over");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a scaling factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor); //broken
                        Console.WriteLine($"\nHere is the scaled recipe (by a factor of {factor}):");
                        recipe.DisplayRecipe();
                        break;

                    case 2:
                        recipe.ResetQuantities();
                        Console.WriteLine("\nQuantities have been reset to their original values.");
                        recipe.DisplayRecipe();
                        break;

                    case 3:
                        Console.Write("\nPLease re-enter :  ");
                        recipe.EnterIngredients();

                        Console.Write("Please re- emter : ");
                        recipe.EnterSteps();

                        Console.WriteLine("\nHere is the new recipe:");
                        recipe.DisplayRecipe();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }
    }
}