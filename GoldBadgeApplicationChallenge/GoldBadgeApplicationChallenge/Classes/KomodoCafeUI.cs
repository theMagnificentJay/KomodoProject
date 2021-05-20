using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge
{
    public class KomodoCafeUI
    {
        private MealRepo _repo = new MealRepo();
        public void Run()
        {
            SeedContentMeals();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\tWelcome to Komodo Cafe, select and option:\n" +
                    "\n" +
                    "\t1. Order\n" +
                    "\t2. Settings\n" +
                    "\t3. Exit\n\t");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    // Order - customer interaction
                    case "1":
                        Order();
                        break;
                    // Settings - admin menu to add, remove, or update menu items
                    case "2":
                        Console.Clear();
                        KomodoTitle();
                        Settings();
                        break;
                    // Exit - exit program
                    case "3":
                        Console.Clear();
                        keepRunning = false;
                        KomodoTitle();
                        Console.WriteLine("\n\tExiting Komodo Cafe...");
                        Thread.Sleep(1000); // sleep 1s
                        break;
                    default:
                        Console.Clear();
                        KomodoTitle();
                        Console.WriteLine("\n\tPlease enter a valid option.");
                        Thread.Sleep(1000); // sleep 1s
                        break;
                }
            }
        }

        private void Order()
        {
            List<Meal> allMeals = _repo.ViewMealMenu();
            bool ordering = true;
            while (ordering)
            {
                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\tWould you like to see our menu options, [y]es [n]o or e[x]it?\n");
                string input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "yes")
                {
                    Console.Clear();
                    KomodoTitle();
                    foreach (Meal meal in allMeals)
                    {
                        Console.WriteLine($"\n\t#{meal.MealNumber} {meal.MealName} for ${meal.MealPrice}\n\tDescription: {meal.MealDescription}");
                        Console.Write("\tIngredients: ");
                        foreach (string ingredient in meal.MealIngredients)
                        {
                            Console.Write($"{ingredient} ");
                        }
                        Console.WriteLine();
                    }
                    Continue();
                }
                else if (input.ToLower() == "n" || input.ToLower() == "no")
                {
                    Console.Clear();
                    KomodoTitle();
                    Continue();
                }
                else if (input.ToLower() == "x" || input.ToLower() == "exit")
                {
                    Console.Clear();
                    KomodoTitle();
                    ordering = false;
                    Console.WriteLine("\n\tReturning to main menu...");
                    Thread.Sleep(1000); // sleep 1s
                }
                else
                {
                    Console.Clear();
                    KomodoTitle();
                    Console.WriteLine("\n\tPlease enter a valid option.");
                    Thread.Sleep(1000); // sleep 1s
                }
            }
        }

        private void Settings()
        {
            Console.WriteLine("\n\tPassword: ");
            string password = null;
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            if (password == "admin")
            {
                bool settingsMenu = true;
                while (settingsMenu)
                {
                    Console.Clear();
                    KomodoTitle();
                    Console.WriteLine("\n\tSettings Menu, select one of the options below:\n" +
                        "\n" +
                        "\t1. Add Meal\n" +
                        "\t2. Update Meal\n" +
                        "\t3. Delete Meal\n" +
                        "\t4. View Menu\n" +
                        "\t5. Exit\n");
                    string input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "1":
                            // Add Meal
                            AdminAddMeal();
                            Continue();
                            break;
                        case "2":
                            // Update Meal
                            AdminUpdateMeal();
                            Continue();
                            break;
                        case "3":
                            // Delete Meal
                            AdminDeleteMenuItem();
                            Continue();
                            break;
                        case "4":
                            // View Meal
                            AdminViewMenu();
                            Continue();
                            break;
                        case "5":
                            // Exit
                            settingsMenu = false;
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\tAccess Denied.");
                Thread.Sleep(1000); // sleep 1s
            }
        }

        private void AdminAddMeal()
        {
            List<Meal> allMeals = _repo.ViewMealMenu();
            Meal newMeal = new Meal();
            Console.Clear();
            KomodoTitle();
            Console.WriteLine("\n\n\tEnter the meal number for the new meal.");
            Console.Write($"\n\tMeal numbers that are currently being used: ");
            foreach (Meal meal in allMeals)
            {
                Console.Write($"#{meal.MealNumber} ");
            }
            Console.WriteLine();
            newMeal.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            KomodoTitle();
            Console.WriteLine($"\n\n\tEnter a name for meal order number {newMeal.MealNumber}.");
            newMeal.MealName = Console.ReadLine();
            
            Console.Clear();
            KomodoTitle();
            Console.WriteLine($"\n\n\tEnter a description for {newMeal.MealName}.");
            newMeal.MealDescription = Console.ReadLine();

            Console.Clear();
            KomodoTitle();
            Console.WriteLine($"\n\n\tLeaving a space between each, add the ingredients of {newMeal.MealName}.");
            string ingredients = Console.ReadLine();
            newMeal.MealIngredients = ingredients.Split(' ').ToList();

            Console.Clear();
            KomodoTitle();
            Console.WriteLine($"\n\n\tEnter a price for {newMeal.MealName}.");
            newMeal.MealPrice = Convert.ToDouble(Console.ReadLine());

            bool wasUpdated = _repo.AddMealToMenu(newMeal);
            if (wasUpdated)
            {
                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\n\tMeal updated with new information.");
                Console.WriteLine($"\n\t#{newMeal.MealNumber} {newMeal.MealName} for ${newMeal.MealPrice}\n\tDescription: {newMeal.MealDescription}");
                Console.Write("\tIngredients: ");
                foreach (string ingredient in newMeal.MealIngredients)
                {
                    Console.Write($"{ingredient} ");
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Meal could not be added.");
        }

        private void AdminUpdateMeal()
        {
            Console.Clear();
            KomodoTitle();
            AdminViewMenu();
            Console.WriteLine("\n\tEnter the name of the meal you would like to update.");
            string oldMeal = Console.ReadLine();
            Meal meal = _repo.SearchMealByName(oldMeal);
            if (_repo.SearchMealByName(oldMeal) != null)
            {
                Meal newMeal = new Meal();
                Console.Clear();
                KomodoTitle();
                Console.WriteLine($"\n\n\tCurrent meal number: {meal.MealNumber}. Input new/same meal number?\n");
                newMeal.MealNumber = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                KomodoTitle();
                Console.WriteLine($"\n\n\tCurrent meal name: {meal.MealName}. Input new/same meal name?");
                newMeal.MealName = Console.ReadLine();

                Console.Clear();
                KomodoTitle();
                Console.WriteLine($"\n\n\tCurrent meal description:\n\n\t\"{meal.MealDescription}\"\n\n\tInput new/same meal description?");
                newMeal.MealDescription = Console.ReadLine();

                Console.Clear();
                KomodoTitle();
                Console.Write($"\n\n\tCurrent ingredients: ");
                foreach (string ingredient in meal.MealIngredients)
                {
                    Console.Write($"{ingredient} ");
                }
                Console.WriteLine($"\n\tleaving a space inbetween each ingredient, input new/same ingredients?");
                string ingredients = Console.ReadLine();
                newMeal.MealIngredients = ingredients.Split(' ').ToList(); // This prob doesnt work ?? holy shit this works!

                Console.Clear();
                KomodoTitle();
                Console.WriteLine($"\n\n\tCurrent price: {meal.MealPrice}. Input new/same meal price?");
                newMeal.MealPrice = Convert.ToDouble(Console.ReadLine());

                bool wasUpdated = _repo.UpdateMealToMenu(oldMeal, newMeal);
                if (wasUpdated)
                {
                    Console.Clear();
                    KomodoTitle();
                    Console.WriteLine("\n\n\tMeal updated with new information.");
                    Console.WriteLine($"\n\t#{newMeal.MealNumber} {newMeal.MealName} for ${newMeal.MealPrice}\n\tDescription: {newMeal.MealDescription}");
                    Console.Write("\tIngredients: ");
                    foreach (string ingredient in newMeal.MealIngredients)
                    {
                        Console.Write($"{ingredient} ");
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Meal could not be updated.");
            }
            else
                Console.WriteLine("That meal name didn't return anything.");
        }

        private void AdminViewMenu()
        {
            Console.Clear();
            List<Meal> allMeals = _repo.ViewMealMenu();
            KomodoTitle();
            foreach (Meal meal in allMeals)
            {
                Console.WriteLine($"\n\t#{meal.MealNumber} {meal.MealName} for ${meal.MealPrice}\n\tDescription: {meal.MealDescription}");
                Console.Write("\tIngredients: ");
                foreach (string ingredient in meal.MealIngredients)
                {
                    Console.Write($"{ingredient} ");
                }
                Console.WriteLine();
            }
        }

        private void AdminDeleteMenuItem()
        {
            Console.Clear();
            AdminViewMenu();
            Console.WriteLine("\n\tEnter the name of the menu item you would like to delete.");
            bool wasDeleted = _repo.DeleteMealFromMenu(Console.ReadLine());
            if (wasDeleted)
            {
                Console.WriteLine("\n\n\tMeal deleted.");
            }
            else
                Console.WriteLine("\n\n\tMeal could not be deleted.");
        }

        // Seeded Content
        private void SeedContentMeals()
        {
            Meal burger = new Meal(1, "Burger", "Sandwich consisting of a cooked beef patty, placed inside a bun.", new List<string> { "bun", "beef" }, 9.99);
            _repo.AddMealToMenu(burger);

            Meal cheeseBurger = new Meal(2, "Cheese Burger", "Sandwich consisting of a cooked beef patty with cheese, placed inside a bun.", new List<string> { "bun", "beef", "Cheese" }, 10.99);
            _repo.AddMealToMenu(cheeseBurger);

            Meal fries = new Meal(3, "Fries", "Fried thinly cut potatoe strips", new List<string> { "potatoes" }, 1.99);
            _repo.AddMealToMenu(fries);

            Meal drink = new Meal(4, "Drink", "Drink of your choice", new List<string> { "drink" }, 1.25);
            _repo.AddMealToMenu(drink);
        }

        // ASCII Title Method
        public void KomodoTitle()
        {
            string title = @"
                  :::    ::: ::::::::    :::   :::    ::::::::  :::::::::   :::::::: 
                 :+:   :+: :+:    :+:  :+:+: :+:+:  :+:    :+: :+:    :+: :+:    :+: 
                +:+  +:+  +:+    +:+ +:+ +:+:+ +:+ +:+    +:+ +:+    +:+ +:+    +:+  
               +#++:++   +#+    +:+ +#+  +:+  +#+ +#+    +:+ +#+    +:+ +#+    +:+   
              +#+  +#+  +#+    +#+ +#+       +#+ +#+    +#+ +#+    +#+ +#+    +#+    
             #+#   #+# #+#    #+# #+#       #+# #+#    #+# #+#    #+# #+#    #+#     
            ###    ### ########  ###       ###  ########  #########   ########       
                                  ::::::::      :::     :::::::::: ::::::::::        
                                :+:    :+:   :+: :+:   :+:        :+:                
                               +:+         +:+   +:+  +:+        +:+                 
                              +#+        +#++:++#++: :#::+::#   +#++:++#             
                             +#+        +#+     +#+ +#+        +#+                   
                            #+#    #+# #+#     #+# #+#        #+#                    
                            ########  ###     ### ###        ##########              
                ";
            Console.WriteLine(title);
        }

        // Helper Methods
        private void Continue()
        {
            Console.WriteLine("\n\n\tPress any key to continue...");
            Console.ReadKey();
        }
    }
}
