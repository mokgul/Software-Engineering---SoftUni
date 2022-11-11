
namespace PizzaCalories
{
    using System;
    public class Dough
    {
        private const double FLOUR_TYPE_WHITE = 1.5;
        private const double FLOUR_TYPE_WHOLEGRAIN = 1.0;
        private const double BAKING_TECHNIQUE_CRISPY = 0.9;
        private const double BAKING_TECHNIQUE_CHEWY = 1.1;
        private const double BAKING_TECHNIQUE_HOMEMADE = 1.0;

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double caloriesPerGram = 2;
        public Dough(string flourTypeInput, string bakingTechniqueInput, int weightInput)
        {
            if (flourTypeValid(flourTypeInput))
                this.flourType = flourTypeInput.ToLower();
            if (flourTypeValid(bakingTechniqueInput))
                this.bakingTechnique = bakingTechniqueInput.ToLower();
            if (flourWeightValid(weightInput))
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

        private bool flourTypeValid(string flourType)
        {
            flourType = flourType.ToLower();
            if (flourType != "white"
                && flourType != "wholegrain"
                && flourType != "crispy"
                && flourType != "chewy"
                && flourType != "homemade")
                throw new ArgumentException(ExceptionMessages.INVALID_TYPE_DOUGH);
            return true;
        }

        private bool flourWeightValid(int weight)
        {
            if (weight < 1 || weight > 200)
                throw new ArgumentException(ExceptionMessages.INVALID_WEIGHT_DOUGH);
            return true;
        }
        private double ModifiersCoefficient()
        {
            double coefficient = caloriesPerGram;
            coefficient = (this.flourType == "white") ? coefficient * FLOUR_TYPE_WHITE : coefficient * FLOUR_TYPE_WHOLEGRAIN;
            coefficient =
                (bakingTechnique == "crispy")
                    ? coefficient * BAKING_TECHNIQUE_CRISPY
                        : (this.bakingTechnique == "chewy")
                            ? coefficient * BAKING_TECHNIQUE_CHEWY
                            : coefficient * BAKING_TECHNIQUE_HOMEMADE;
            return double.Parse($"{coefficient:f2}");
        }

        public double TotalCalories => this.weight * CaloriesPerGram;
    }
}
