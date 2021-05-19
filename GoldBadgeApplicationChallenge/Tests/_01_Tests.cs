using GoldBadgeApplicationChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class _01_Tests
    {
        [TestMethod]
        public void AddMeal_ReturnBool()
        {
            bool value;
            Meal meal = new Meal();
            MealRepo _repo = new MealRepo();
            value = _repo.AddMealToMenu(meal);
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void UpdateMeal_ShouldReturnUpdated()
        {
            Meal meal = new Meal();
            MealRepo _repo = new MealRepo();
            meal = new Meal(1, "Burger", "is a burger", new List<string>() { "bun", "beef" }, 9.99);
            _repo.AddMealToMenu(meal);
            _repo.UpdateMealToMenu("burger", new Meal(2, "new burger", "is new burger", new List<string>() { "new bun", "new beef" }, 10.99));
            Assert.AreEqual(meal.MealName, "new burger");
        }

        [TestMethod]
        public void DeleteMeal_ReturnBool()
        {
            Meal meal = new Meal();
            MealRepo _repo = new MealRepo();
            meal = new Meal(1, "Burger", "is a burger", new List<string>() { "bun", "beef" }, 9.99);
            _repo.AddMealToMenu(meal);
            bool value;
            value = _repo.DeleteMealFromMenu("burger");
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void ViewMeals_ShouldReturnMeals()
        {
            Meal meal = new Meal();
            MealRepo _repo = new MealRepo();
            _repo.AddMealToMenu(meal);
            List<Meal> allMeals = _repo.ViewMealMenu();
            bool mealInList = allMeals.Contains(meal);
            Assert.IsTrue(mealInList);
        }
    }
}
