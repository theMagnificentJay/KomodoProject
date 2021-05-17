using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge
{
    public class Meal
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; } = new List<string>();
        public double MealPrice { get; set; }

        public Meal() { }
        public Meal(int mealNumber, string mealName, string mealDescription, List<string> ingredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = ingredients;
            MealPrice = mealPrice;
        }
    }
}
