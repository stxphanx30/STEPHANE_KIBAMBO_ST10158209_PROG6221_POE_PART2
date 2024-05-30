using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POE_PART2
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); // List to store ingredients
        private List<string> stepDescriptions = new List<string>(); // List to store steps

        // Method to get recipe details from user input
        public void GetRecipeDetails()
        {
            Console.WriteLine("Please enter the name of the recipe:");
            Name = Console.ReadLine();

            GetIngredients(); // Get ingredients from user input
            GetSteps(); // Get steps from user input
        }

        // Method to get ingredients from user input
        public void GetIngredients()
        {
            Console.WriteLine("Please enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                double calories = double.Parse(Console.ReadLine());
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }
        }

        // Method to get steps from user input
        public void GetSteps()
        {
            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter description for step {i + 1}:");
                stepDescriptions.Add(Console.ReadLine());
            }
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < stepDescriptions.Count; i++)
            {
                Console.WriteLine($"- {i + 1}. {stepDescriptions[i]}");
            }
            Console.WriteLine($"\nTotal Calories: {CalculateTotalCalories()}");
        }

        // Method to calculate total calories of the recipe
        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories + ingredient.Quantity);
        }

        // Method to scale the recipe quantities
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset the ingredient quantities
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        // Method to clear the recipe data
        public void ClearData()
        {
            Ingredients.Clear();
            stepDescriptions.Clear();
        }
    }
}
