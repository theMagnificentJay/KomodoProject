using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeApplicationChallenge._02_KomodoClaims
{
    public class KomodoClaimsUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoTitle();
            }
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
    }
}
