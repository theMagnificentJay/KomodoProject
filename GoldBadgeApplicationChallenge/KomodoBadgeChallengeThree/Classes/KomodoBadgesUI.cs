using KomodoBadgeChallengeThree.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge._03_KomodoBadges
{
    public class KomodoBadgesUI
    {
        public BadgesRepo _repo = new BadgesRepo();
        public void Run()
        {
            SeededList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\n\tChoose an option:\n" +
                    "\t1. Add a Badge\n" +
                    "\t2. Edit a Badge\n" +
                    "\t3. List all Badges\n" +
                    "\t4. Exit\n");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        // AddBadge
                        AddBadge();
                        break;
                    case 2:
                        // EditBadge
                        EditBadge();
                        break;
                    case 3:
                        // ViewBadges
                        ViewBadges();
                        Continue();
                        break;
                    case 4:
                        Console.Clear();
                        KomodoTitle();
                        Console.WriteLine("\n\n\t Exiting Komodo Badges...");
                        Thread.Sleep(1000); // sleep 1s
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            KomodoTitle();
            Badge badge = new Badge();
            Console.WriteLine("\n\n\tEnter Badge ID: (e.g. 1234)");
            badge.BadgeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n\tEnter the doors this badge has access to (seperated by spaces): (e.g. A1 A2 A3)");
            string doors = Console.ReadLine().ToUpper();
            badge.DoorAccess = doors.Split(' ').ToList();
            _repo.AddNewBadge(badge.BadgeID, badge.DoorAccess);

            Console.Clear();
            KomodoTitle();
            Console.WriteLine("\tAdded new badge with following information:");
            string headerSize = "{0,-15}{1,-25}";
            Console.WriteLine("\tKey\n");
            Console.Write("\t");
            Console.Write(headerSize, "Badge #", "Door Access\n");
            Console.Write("\n\t");
            string doorList = "";
            foreach (string door in badge.DoorAccess)
            {
                doorList += door + " ";
            }
            Console.Write(headerSize, $"{badge.BadgeID}", doors);
            Console.WriteLine();
            Continue();
        }

        private void EditBadge()
        {
            Console.Clear();
            KomodoTitle();
            ViewBadges();
            // get key
            Console.WriteLine("\n\n\tWhat is the badge number to update?");
            int key = Convert.ToInt32(Console.ReadLine());

            // display badge

            // adding door?
            bool editing = true;
            while (editing)
            {
                Console.Clear();
                KomodoTitle();
                ViewBadges();
                Console.WriteLine("\n\n\tWhat would you like to do?\n\n" +
                    "\t1. Remove a door.\n" +
                    "\t2. Add a door.\n");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    bool adding = false;
                    Console.Clear();
                    KomodoTitle();
                    ViewBadges();
                    Console.WriteLine("\n\n\tDoor to remove:");
                    string value = Console.ReadLine().ToUpper();

                    _repo.EditBadge(key, value, adding);

                    Console.WriteLine("Any other doors(y/n)?");
                    string again = Console.ReadLine();
                    switch (again)
                    {
                        case "y":
                        case "yes":
                            break;
                        case "n":
                        case "no":
                            Console.Clear();
                            editing = false;
                            break;
                        default:
                            break;
                    }
                }
                else if (input == 2)
                {
                    bool adding = true;
                    Console.Clear();
                    KomodoTitle();
                    ViewBadges();
                    Console.WriteLine("\n\n\tDoor to add:");
                    string value = Console.ReadLine().ToUpper();

                    _repo.EditBadge(key, value, adding);

                    Console.WriteLine("Any other doors(y/n)?");
                    string again = Console.ReadLine();
                    switch (again)
                    {
                        case "y":
                        case "yes":
                            break;
                        case "n":
                        case "no":
                            Console.Clear();
                            editing = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                    return;
            }
            Console.Clear();
            KomodoTitle();
            Console.WriteLine("\n\n\tReturning to menu...");
            Thread.Sleep(1000); // sleep 1s
        }

        private void ViewBadges()
        {
            Console.Clear();
            KomodoTitle();
            Dictionary<int, List<string>> allBadges = _repo.ViewBadges();
            string headerSize = "{0,-15}{1,-25}";
            Console.WriteLine("\tKey\n");
            Console.Write("\t");
            Console.Write(headerSize, "Badge #", "Door Access\n");
            foreach (var badge in allBadges)
            {
                Console.Write("\n\t");
                string doors = "";
                foreach (string door in badge.Value)
                {
                    doors += door + " ";
                }
                Console.Write(headerSize, $"{badge.Key}", doors);
                Console.WriteLine();
            }
        }

        private void KomodoTitle()
        {
            string title = @"
        
              :::    ::: ::::::::    :::   :::    ::::::::  :::::::::   ::::::::   
             :+:   :+: :+:    :+:  :+:+: :+:+:  :+:    :+: :+:    :+: :+:    :+:   
            +:+  +:+  +:+    +:+ +:+ +:+:+ +:+ +:+    +:+ +:+    +:+ +:+    +:+    
           +#++:++   +#+    +:+ +#+  +:+  +#+ +#+    +:+ +#+    +:+ +#+    +:+     
          +#+  +#+  +#+    +#+ +#+       +#+ +#+    +#+ +#+    +#+ +#+    +#+      
         #+#   #+# #+#    #+# #+#       #+# #+#    #+# #+#    #+# #+#    #+#       
        ###    ### ########  ###       ###  ########  #########   ########         
                  :::::::::      :::     :::::::::   ::::::::  :::::::::: :::::::: 
                 :+:    :+:   :+: :+:   :+:    :+: :+:    :+: :+:       :+:    :+: 
                +:+    +:+  +:+   +:+  +:+    +:+ +:+        +:+       +:+         
               +#++:++#+  +#++:++#++: +#+    +:+ :#:        +#++:++#  +#++:++#++   
              +#+    +#+ +#+     +#+ +#+    +#+ +#+   +#+# +#+              +#+    
             #+#    #+# #+#     #+# #+#    #+# #+#    #+# #+#       #+#    #+#     
            #########  ###     ### #########   ########  ########## ########       

            ";
            Console.WriteLine(title);
        }

        private void Continue()
        {
            Console.WriteLine("\n\n\tPress any key to continue...");
            Console.ReadKey();
        }

        private void SeededList()
        {
            Badge bOne = new Badge();
            bOne.BadgeID = 12345;
            bOne.DoorAccess = new List<string>() { "A7" };
            _repo.AddNewBadge(bOne.BadgeID, bOne.DoorAccess);

            Badge bTwo = new Badge();
            bTwo.BadgeID = 22345;
            bTwo.DoorAccess = new List<string>() { "A1", "A4", "B1", "B2" };
            _repo.AddNewBadge(bTwo.BadgeID, bTwo.DoorAccess);

            Badge bThree = new Badge();
            bThree.BadgeID = 32345;
            bThree.DoorAccess = new List<string>() { "A4", "A5" };
            _repo.AddNewBadge(bThree.BadgeID, bThree.DoorAccess);
        }
    }
}
