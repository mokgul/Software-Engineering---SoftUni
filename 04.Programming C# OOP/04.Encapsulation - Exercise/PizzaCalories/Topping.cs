
namespace PizzaCalories
{
    using System;
    public class Topping
    {
        private const double TOPPING_MEAT = 1.2;
        private const double TOPPING_VEGGIES = 0.8;
        private const double TOPPING_CHEESE = 1.1;
        private const double TOPPING_SAUSE = 0.9;

        private string toppingType;
        private int weight;
        private double caloriesPerGram = 2;

        public Topping(string toppingTypeInput, int weightInput)
        {
            if (ToppingTypeValid(toppingTypeInput))
                this.toppingType = toppingTypeInput.ToLower();
            if (ToppingWeightValid(weightInput, toppingTypeInput))
                this.weight = weightInput;
            CaloriesPerGram = caloriesPerGram;
        }

        public double CaloriesPerGram
        {
            get => caloriesPerGram;
            private set
            {
                value = ModifiersCoefficient();
                caloriesPerGram = value;
            }
        }
        private bool ToppingTypeValid(string toppingTypeInput)
        {
            string temp = toppingTypeInput;
            toppingTypeInput = toppingTypeInput.ToLower();
            if (toppingTypeInput != "meat"
                && toppingTypeInput != "veggies"
                && toppingTypeInput != "cheese"
                && toppingTypeInput != "sauce")
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TOPPING_TYPE, temp));
            return true;
        }

        private bool ToppingWeightValid(int weightInput, string toppingTypeInput)
        {
            if (weightInput < 1 || weightInput > 50)
                throw new ArgumentException(string.Format(ExceptionMessages.INVALID_TOPPING_WEIGHT, toppingTypeInput));
            return true;
        }
        private double ModifiersCoefficient()
        {
            double coefficient = caloriesPerGram;
            coefficient = (toppingType == "meat")
                ? coefficient * TOPPING_MEAT
                : (toppingType == "veggies")
                ? coefficient * TOPPING_VEGGIES
                : (toppingType == "cheese")
                ? coefficient * TOPPING_CHEESE
                : coefficient * TOPPING_SAUSE;
            return double.Parse($"{coefficient:f2}");
        }

        public double TotalCalories => this.weight * CaloriesPerGram;
    }
}
