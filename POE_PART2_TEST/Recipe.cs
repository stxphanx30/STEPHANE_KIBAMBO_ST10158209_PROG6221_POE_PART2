using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART2_TEST
{
    /// <summary>
    /// clone of the recipe.cs class in the project for ujnit testing whith only the total calories method to test 
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    ///
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); // List to store ingredients

        /// <summary>
        /// methot to test the calculation of the total calory
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        ///
        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories + ingredient.Quantity);
        }
    }
}
