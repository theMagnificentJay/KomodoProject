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
            //SeededContentClaims();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
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
                        break;
                    case 3:
                        // ViewBadges
                        ViewBadges();
                        break;
                    case 4:
                        Console.Clear();
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
            Badge badge = new Badge();
            Console.WriteLine("\n\n\tEnter Badge ID: (e.g. 1234)");
            badge.BadgeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n\tEnter the doors this badge has access to (seperated by spaces): (e.g. A1 A2 A3)");
            string doors = Console.ReadLine();
            badge.DoorAccess = doors.Split(' ').ToList();
            _repo.AddNewBadge(badge.BadgeID, badge.DoorAccess);
        }

        private void ViewBadges()
        {
            Dictionary<int, List<string>> allBadges = _repo.ViewBadges();
            foreach (var badge in allBadges)
            {
                Console.Write($"\n\tID: {badge.Key} Doors: ");
                foreach (string door in badge.Value)
                {
                    Console.Write($"{door} ");
                }
            }
            Console.ReadKey();
        }
    }
}
