using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const double FLOUR_TYPE_WHITE = 1.5;
        private const double FLOUR_TYPE_WHOLEGRAIN = 1.0;
        private const double BAKING_TECHNIQUE_CRISPY = 0.9;
        private const double BAKING_TECHNIQUE_CHEWY = 1.1;
        private const double BAKING_TECHNIQUE_HOMEMADE = 1.0;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            if(flourTypeValid(flourType))
                this.flourType = flourType;
            if(flourTypeValid(bakingTechnique))
                this.bakingTechnique = bakingTechnique;
            if(flourWeightValid(weight))
                this.weight = weight;
            CaloriesPerGram = caloriesPerGram;
        }

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double caloriesPerGram = 2;

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
            if (flourType != "White"
                && flourType != "Wholegrain"
                && flourType != "Crispy"
                && flourType != "Chewy"
                && flourType != "Homemade")
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
            coefficient = this.flourType == "White" ? coefficient * FLOUR_TYPE_WHITE : coefficient * FLOUR_TYPE_WHOLEGRAIN;
            coefficient =
                bakingTechnique == "Crispy"
                    ? coefficient * BAKING_TECHNIQUE_CRISPY
                        : this.bakingTechnique == "Chewy"
                            ? coefficient * BAKING_TECHNIQUE_CHEWY
                            : coefficient * BAKING_TECHNIQUE_HOMEMADE;
            return double.Parse($"{coefficient:f2}");
        }

        public double TotalCalories => this.weight * CaloriesPerGram;
    }
}
