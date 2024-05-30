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

        // List to store ingredients
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); 

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
