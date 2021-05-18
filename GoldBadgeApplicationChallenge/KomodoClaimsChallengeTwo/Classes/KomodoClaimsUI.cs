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
                        break;
                    case "3":
                        // NewClaim
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

        }

        private void NewClaim()
        {

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
