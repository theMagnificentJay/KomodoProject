using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge
{
    public class MealRepo
    {
        public readonly List<Meal> _mealMenu = new List<Meal>();

        // CRUD w/ add [x], update [x], delete [x], and view all [x] meals in the menu list

        // AddMealToMenu - return true if meal was added to menu
        public bool AddMealToMenu(Meal newMeal)
        {
            int startingCount = _mealMenu.Count;
            _mealMenu.Add(newMeal);
            bool mealAdded = (_mealMenu.Count > startingCount) ? true : false;
            return mealAdded;
        }

        // UpdateMealToMenu
        public bool UpdateMealToMenu(string ogMealName, Meal newMeal)
        {
            Meal oldMeal = SearchMealByName(ogMealName);

            if (oldMeal != null)
            {
                oldMeal.MealNumber = newMeal.MealNumber;
                oldMeal.MealName = newMeal.MealName;
                oldMeal.MealDescription = newMeal.MealDescription;
                oldMeal.MealIngredients = newMeal.MealIngredients;
                oldMeal.MealPrice = newMeal.MealPrice;

                return true;
            }
            else
                return false;
        }

        // DeleteMealFromMenu - delete meal from menu
        public bool DeleteMealFromMenu(string mealToDelete)
        {
            Meal contentToDelete = SearchMealByName(mealToDelete);
            if (contentToDelete != null)
            {
                _mealMenu.Remove(contentToDelete);
                return true;
            }
            else
                return false;
        }

        // ViewMealMenu - read all
        public List<Meal> ViewMealMenu()
        {
            return _mealMenu;
        }

        // SearchMealByName - search meal by name
        public Meal SearchMealByName(string mealName)
        {
            foreach (Meal meal in _mealMenu)
            {
                if (meal.MealName.ToLower() == mealName.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
