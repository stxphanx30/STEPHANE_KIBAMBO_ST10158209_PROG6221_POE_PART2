using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART2
{
    class RecipeApp
    {
        private List<Recipe> recipes = new List<Recipe>(); // List to store recipes
        public delegate void CalorieNotification(string message); // Delegate for calorie notification

        // Main application loop
        public void Run()
        {
            bool stay = true;
            while (stay)
            {
                // Set menu text color to gray
                Console.ForegroundColor = ConsoleColor.DarkYellow; 
                Console.WriteLine("Hi, welcome to our storing ingredient app");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display recipes");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe data");
                Console.WriteLine("6. Exit");

                // Reset color to default
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewRecipe();
                        break;
                    case 2:
                        DisplayRecipes();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        ResetQuantities();
                        break;
                    case 5:
                        ClearRecipeData();
                        break;
                    case 6:
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }

        // Method to add a new recipe
        private void AddNewRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.GetRecipeDetails(); // Get recipe details from user input
            recipes.Add(recipe); // Add the new recipe to the list

            // Notify if total calories exceed 300
            if (recipe.CalculateTotalCalories() > 300)
            {
                CalorieNotification notify = NotifyCalorieLimitExceeded;
                notify($"The total calories of the recipe '{recipe.Name}' exceed 300!");
            }
        }

        // Method to display all recipes
        private void DisplayRecipes()
        {
            // Set menu text color to gray
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("Recipes:");

            // Reset color to default
            Console.ResetColor(); 
            foreach (var recipe in recipes.OrderBy(r => r.Name)) // Display recipes in alphabetical order
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("Enter the name of the recipe you want to display:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe(); // Display the selected recipe
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to scale a recipe
        private void ScaleRecipe()
        {
            Console.WriteLine("Enter the name of the recipe you want to scale:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                Console.WriteLine("By how much would you like your quantities to be changed?:");
                double factor = double.Parse(Console.ReadLine());
                selectedRecipe.ScaleRecipe(factor); // Scale the recipe quantities
                Console.WriteLine("The quantities have been updated. Here are the new quantities:");
                selectedRecipe.DisplayRecipe(); // Display the scaled recipe
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to reset recipe quantities
        private void ResetQuantities()
        {
            Console.WriteLine("Enter the name of the recipe you want to reset:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                selectedRecipe.ResetQuantities(); // Reset the recipe quantities
                Console.WriteLine("The quantity values have been reset.");
                selectedRecipe.DisplayRecipe(); // Display the reset recipe
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to clear recipe data
        private void ClearRecipeData()
        {
            Console.WriteLine("Enter the name of the recipe you want to clear:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                selectedRecipe.ClearData(); // Clear the recipe data
                recipes.Remove(selectedRecipe); // Remove the recipe from the list
                Console.WriteLine("The recipe data has been cleared.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to notify if calorie limit is exceeded
        private void NotifyCalorieLimitExceeded(string message)
        {
            // Set text color to red
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine(message);
            // Reset color to default
            Console.ResetColor(); 
        }
    }
}
