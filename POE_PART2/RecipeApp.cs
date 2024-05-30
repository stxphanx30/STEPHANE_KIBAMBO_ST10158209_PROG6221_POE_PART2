using System;
using System.Collections.Generic;
using System.Linq;

namespace POE_PART2
{
    /// <summary>
    /// this class contains the menu and options that the user will be able prompt to insert their choise and has some methods that we will use along the program to allow the user to act
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 
    class RecipeApp
    {
        // List to store recipes
        private List<Recipe> recipes = new List<Recipe>(); 

        // Delegate for calorie notification
        public delegate void CalorieNotification(string message); 

        /// <summary>
        /// this is the method run that the program will start and display the menu and calls other methon within the class
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        public void Run()
        {
            bool stay = true;
            while (stay)
            {
                // Set menu text color to gray
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                
                // menu
                Console.WriteLine("Hi, welcome to our storing ingredient app");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display recipes");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe data");
                Console.WriteLine("6. Exit");

                // Reset color to default
                Console.ResetColor();
                
                // switch to get the user input
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

        /// <summary>
        ///this method will allow us to add a new recipe
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        private void AddNewRecipe()
        {
            Recipe recipe = new Recipe();

            // Get recipe details from user input
            recipe.GetRecipeDetails(); 

            // Add the new recipe to the list
            recipes.Add(recipe); 

            // Notify if total calories exceed 300
            if (recipe.CalculateTotalCalories() > 300)
            {
                CalorieNotification notify = NotifyCalorieLimitExceeded;
                notify($"The total calories of the recipe '{recipe.Name}' exceed 300!");
            }
        }

        /// <summary>
        /// this method allow us to display the recipes
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        private void DisplayRecipes()
        {
            // Set menu text color to gray
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("Recipes:");

            // Reset color to default
            Console.ResetColor();

            // Display recipes in alphabetical order
            foreach (var recipe in recipes.OrderBy(r => r.Name)) 
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("Enter the name of the recipe you want to display:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                // Display the selected recipe
                selectedRecipe.DisplayRecipe(); 
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        /// <summary>
        /// Method to scale the recipe
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        private void ScaleRecipe()
        {
            Console.WriteLine("Enter the name of the recipe you want to scale:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                Console.WriteLine("By how much would you like your quantities to be changed?:");
                double factor = double.Parse(Console.ReadLine());

                // Scale the recipe quantities
                selectedRecipe.ScaleRecipe(factor); 
                Console.WriteLine("The quantities have been updated. Here are the new quantities:");

                // Display the scaled recipe
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        /// <summary>
        /// Method to reset the quantities
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        private void ResetQuantities()
        {
            Console.WriteLine("Enter the name of the recipe you want to reset:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                // Reset the recipe quantities
                selectedRecipe.ResetQuantities();
                Console.WriteLine("The quantity values have been reset.");

                // Display the reset recipe
                selectedRecipe.DisplayRecipe(); 
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        /// <summary>
        /// Method to clear the datas from the collection
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
        private void ClearRecipeData()
        {
            Console.WriteLine("Enter the name of the recipe you want to clear:");
            string recipeName = Console.ReadLine();
            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                // Clear the recipe data
                selectedRecipe.ClearData();

                // Remove the recipe from the list
                recipes.Remove(selectedRecipe); 
                Console.WriteLine("The recipe data has been cleared.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        /// <summary>
        /// method to notify if the calories has exeeded 300
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        /// 
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
