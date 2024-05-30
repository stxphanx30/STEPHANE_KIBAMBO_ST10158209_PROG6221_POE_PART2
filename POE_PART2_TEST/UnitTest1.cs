namespace POE_PART2_TEST
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void CalculateTotalCalories_WhenCalled_ReturnsCorrectTotal()
        {
            // Arrange: Set up the ingredients for the test
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

            // Act: Calculate the total calories
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert: Verify the calculated total calories
            // Based on your method, total calories should be sum of calories and quantity
            double expectedCalories = (100 + 2) + (200 + 1) + (400 + 0.5); // 703.5
            Assert.That(totalCalories, Is.EqualTo(expectedCalories));
        }
    }
}