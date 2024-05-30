using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_PART2_TEST
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); // List to store ingredients

        // Method to calculate total calories of the recipe
        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories + ingredient.Quantity);
        }
    }
}
