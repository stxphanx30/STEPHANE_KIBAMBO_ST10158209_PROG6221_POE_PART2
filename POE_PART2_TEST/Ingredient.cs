﻿namespace POE_PART2_TEST
{
    /// <summary>
    /// clone of the Ingredient.cs class in the project for ujnit testing that stores the ingredients
    /// </summary>
    /// /// --------------------------------------------------------------------------------------------------------------------------------------------
    ///
    public class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public double Calories { get; }
        public string FoodGroup { get; }
        private double originalQuantity;

        // Constructor to initialize the ingredient
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            originalQuantity = quantity;
        }

        // Method to reset the ingredient quantity
        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }
    }
}