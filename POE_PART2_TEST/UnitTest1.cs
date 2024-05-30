namespace POE_PART2_TEST
{
    /// <summary>
    /// Unit testing for the project
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    /// 
    [TestFixture]  
    public class RecipeTests
    {
        /// <summary>
        /// methot that test if the total calories calculation works
        /// </summary>
        /// /// --------------------------------------------------------------------------------------------------------------------------------------------
        ///
        [Test]        
        public void CalculateTotalCalories_WhenCalled_ReturnsCorrectTotal()
        {
            // Set up the ingredients for the test
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Flour", 2, "cups", 100, "Grain"),
                new Ingredient("Sugar", 1, "cup", 200, "Sweetener"),
                new Ingredient("Butter", 0.5, "cup", 400, "Dairy")
            };
            var recipe = new Recipe
            {
                Name = "Cake",
                Ingredients = ingredients
            };

            //  Calculate the total calories
            double totalCalories = recipe.CalculateTotalCalories();

            // A Verify the calculated total calories
            // 703.5 expected
            double expectedCalories = (100 + 2) + (200 + 1) + (400 + 0.5); 
            Assert.That(totalCalories, Is.EqualTo(expectedCalories));
        }
    }
}