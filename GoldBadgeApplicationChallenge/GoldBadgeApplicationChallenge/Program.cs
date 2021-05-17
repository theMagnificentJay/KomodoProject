// using GoldBadgeApplicationChallenge._01_KomodoCafe;
using GoldBadgeApplicationChallenge._02_KomodoClaims;
using GoldBadgeApplicationChallenge._03_KomodoBadges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            KomodoCafeUI cafeUI = new KomodoCafeUI();
            KomodoClaimsUI claimsUI = new KomodoClaimsUI();
            KomodoBadgesUI badgesUI = new KomodoBadgesUI();
            Console.WriteLine("Select and option:\n" +
                "1. Komodo Cafe\n" +
                "2. Komodo Claims\n" +
                "3. Komodo Badges\n");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    cafeUI.Run();
                    break;
                case "2":
                    Console.WriteLine("Komodo Claims");
                    claimsUI.Run();
                    break;
                case "3":
                    Console.WriteLine("Komodo Badges");
                    // badgesUI.Run();
                    break;
            }
        }
    }
}
