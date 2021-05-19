using GoldBadgeApplicationChallenge;
using GoldBadgeApplicationChallenge._02_KomodoClaims;
using GoldBadgeApplicationChallenge._03_KomodoBadges;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace _00_KomodoRun
{
    public class StartMenu
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;
        public void Run()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            KomodoCafeUI cafeUI = new KomodoCafeUI();
            KomodoClaimsUI claimsUI = new KomodoClaimsUI();
            KomodoBadgesUI badgesUI = new KomodoBadgesUI();

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                string title = @"
            
                  :::    ::: ::::::::    :::   :::    ::::::::  :::::::::   ::::::::                                           
                 :+:   :+: :+:    :+:  :+:+: :+:+:  :+:    :+: :+:    :+: :+:    :+:                                           
                +:+  +:+  +:+    +:+ +:+ +:+:+ +:+ +:+    +:+ +:+    +:+ +:+    +:+                                            
               +#++:++   +#+    +:+ +#+  +:+  +#+ +#+    +:+ +#+    +:+ +#+    +:+                                             
              +#+  +#+  +#+    +#+ +#+       +#+ +#+    +#+ +#+    +#+ +#+    +#+                                              
             #+#   #+# #+#    #+# #+#       #+# #+#    #+# #+#    #+# #+#    #+#                                               
            ###    ### ########  ###       ###  ########  #########   ########                                                 
                  ::::::::  :::    :::     :::     :::        :::        :::::::::: ::::    :::  ::::::::  :::::::::: :::::::: 
                :+:    :+: :+:    :+:   :+: :+:   :+:        :+:        :+:        :+:+:   :+: :+:    :+: :+:       :+:    :+: 
               +:+        +:+    +:+  +:+   +:+  +:+        +:+        +:+        :+:+:+  +:+ +:+        +:+       +:+         
              +#+        +#++:++#++ +#++:++#++: +#+        +#+        +#++:++#   +#+ +:+ +#+ :#:        +#++:++#  +#++:++#++   
             +#+        +#+    +#+ +#+     +#+ +#+        +#+        +#+        +#+  +#+#+# +#+   +#+# +#+              +#+    
            #+#    #+# #+#    #+# #+#     #+# #+#        #+#        #+#        #+#   #+#+# #+#    #+# #+#       #+#    #+#     
            ########  ###    ### ###     ### ########## ########## ########## ###    ####  ########  ########## ########       
            
                ";
                Console.WriteLine(title + "\n\n");
                Console.WriteLine("\tSelect and option:\n" +
                    "\t1. Komodo Cafe\n" +
                    "\t2. Komodo Claims\n" +
                    "\t3. Komodo Badges\n" +
                    "\t4. Exit\n");
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
                        badgesUI.Run();
                        break;
                    case "4":
                        keepRunning = false;
                        Console.Clear();
                        Console.WriteLine(title + "\n\n");
                        Console.WriteLine("\tExiting Komodo Programs...");
                        Thread.Sleep(1000); // sleep 1s
                        break;
                }
            }
        }
    }
}
