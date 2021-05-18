using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge._02_KomodoClaims
{
    public class KomodoClaimsUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();

        public void Run()
        {
            SeededContentClaims();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoTitle();
                Console.WriteLine("\n\n\tChoose a menu item:\n" +
                    "\n\t1. See all claims\n" +
                    "\t2. Take care of next claim\n" +
                    "\t3. Enter a new claim\n" +
                    "\t4. Exit\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // ViewClaims
                        ViewClaims();
                        break;
                    case "2":
                        // NextClaim
                        NextClaim();
                        break;
                    case "3":
                        // NewClaim
                        NewClaim();
                        break;
                    case "4":
                        // Exit
                        Console.Clear();
                        KomodoTitle();
                        Console.WriteLine("\n\n\tExiting Komodo Claims...");
                        Thread.Sleep(1000); // sleep 1s
                        keepRunning = false;
                        break;
                }
            }
        }

        private void ViewClaims()
        {
            Console.Clear();
            KomodoTitle();
            Console.WriteLine();
            Queue<Claims> allClaims = _repo.ViewClaims();

            string headerSize = "{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-10}";

            Console.Write("\t");
            Console.Write(headerSize,"ClaimID","Type","Description","Amount","DateOfAccident","DateOfClaim","IsValid\n\n");

            foreach (Claims claims in allClaims)
            {
                Console.Write("\t");
                Console.Write(headerSize, $"{claims.ClaimID}", $"{claims.ClaimType}", $"{claims.Description}", $"${claims.ClaimAmount}", $"{claims.DateOfIncident.ToString("MM/dd/yy")}", $"{claims.DateOfClaim.ToString("MM/dd/yy")}", $"{claims.IsValid}\n\n");
            }
            Continue();
        }

        private void NextClaim()
        {
            Console.Clear();
            KomodoTitle();
            Console.WriteLine();
            Claims claim = _repo.PeekNextClaim();

            string headerSize = "{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-10}";
            Console.Write("\t");
            Console.Write(headerSize, "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid\n\n");
            Console.Write("\t");
            Console.Write(headerSize, $"{claim.ClaimID}", $"{claim.ClaimType}", $"{claim.Description}", $"${claim.ClaimAmount}", $"{claim.DateOfIncident.ToString("MM/dd/yy")}", $"{claim.DateOfClaim.ToString("MM/dd/yy")}", $"{claim.IsValid}\n\n");

            Console.WriteLine("\n\tDo you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                _repo.NextClaim(claim);
                return;
            }
            else if (input == "n" || input == "no")
                return;
            else
                NextClaim();
        }

        private void NewClaim()
        {
            Console.Clear();
            KomodoTitle();
            Console.WriteLine();
            Claims newClaim = new Claims();
            Console.WriteLine($"\n\tEnter the claim ID: ");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
            bool choosingType = true;
            while (choosingType)
            {
            Console.WriteLine($"\n\tEnter the claim type:\n" +
                $"\t1. Car\n" +
                $"\t2. Home\n" +
                $"\t3. Theft\n");
                int input = Convert.ToInt32(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        newClaim.ClaimType = (ClaimType)1;
                        choosingType = false;
                        break;
                    case 2:
                        newClaim.ClaimType = (ClaimType)2;
                        choosingType = false;
                        break;
                    case 3:
                        newClaim.ClaimType = (ClaimType)3;
                        choosingType = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"\n\tEnter the claim description: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine($"\n\tEnter amount of damage: (e.g. 1.00)");
            newClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"\n\tEnter the date of the incident: (mm/dd/yyyy)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"\n\tEnter the date of the claim: (mm/dd/yyyy)");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            _repo.AddClaim(newClaim);

            Console.Clear();
            KomodoTitle();
            Console.WriteLine();
            bool wasUpdated = _repo.AddClaim(newClaim);
            if (wasUpdated)
            {
                Console.WriteLine("\n\tAdded the following claim to queue...\n");
                string headerSize = "{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-10}";
                Console.Write("\t");
                Console.Write(headerSize, "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid\n\n");
                Console.Write("\t");
                Console.Write(headerSize, $"{newClaim.ClaimID}", $"{newClaim.ClaimType}", $"{newClaim.Description}", $"${newClaim.ClaimAmount}", $"{newClaim.DateOfIncident.ToString("MM/dd/yy")}", $"{newClaim.DateOfClaim.ToString("MM/dd/yy")}", $"{newClaim.IsValid}\n\n");
            }
            else
                Console.WriteLine("\n\tThe claim could not be added.");
            Continue();
        }

        // Helper Methods
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
              ::::::::  :::            :::     :::::::::::   :::   :::    ::::::::  
            :+:    :+: :+:          :+: :+:       :+:      :+:+: :+:+:  :+:    :+:  
           +:+        +:+         +:+   +:+      +:+     +:+ +:+:+ +:+ +:+          
          +#+        +#+        +#++:++#++:     +#+     +#+  +:+  +#+ +#++:++#++    
         +#+        +#+        +#+     +#+     +#+     +#+       +#+        +#+     
        #+#    #+# #+#        #+#     #+#     #+#     #+#       #+# #+#    #+#      
        ########  ########## ###     ### ########### ###       ###  ########        
            ";
            Console.WriteLine(title);
        }

        private void Continue()
        {
            Console.WriteLine("\n\n\tPress any key to continue...");
            Console.ReadKey();
        }

        // Seeded Content
        private void SeededContentClaims()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            _repo.AddClaim(claimOne);
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            _repo.AddClaim(claimTwo);
            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 18));
            _repo.AddClaim(claimThree);
        }
    }
}
